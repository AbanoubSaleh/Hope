using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.LookUps.Dtos;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Hope.Infrastructure.Services;

public class MissingPersonService : IMissingPersonService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<MissingPersonService> _logger;

    // Add this to the constructor parameters
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MissingPersonService(
        ApplicationDbContext context, 
        ILogger<MissingPersonService> logger,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    // Then in your CreateCompleteReportAsync method:
    public async Task<Result<Guid>> CreateCompleteReportAsync(CreateReportDto reportDto)
    {
        try
        {
            // Get the current user ID from the HttpContext
            string? userId = null;
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            // Validate all foreign keys first
            var center = await _context.Centers.FindAsync(reportDto.CenterId);
            if (center == null)
            {
                return Result<Guid>.Failure("Center not found");
            }

            var government = await _context.Governments.FindAsync(reportDto.GovernmentId);
            if (government == null)
            {
                return Result<Guid>.Failure("Government not found");
            }

            // Create the report using the factory method
            var report = Report.Create(
                reportDto.PhoneNumber,
                reportDto.IncidentTime,
                reportDto.ReportType,
                reportDto.ReportSubjectType,
                reportDto.CenterId,
                reportDto.GovernmentId,
                userId); // Pass the userId

            // Add missing person if applicable
            if (reportDto.ReportSubjectType == ReportSubjectType.Person)
            {
                // Create missing person using factory method
                var missingPerson = MissingPerson.Create(
                    reportDto.PersonName!,
                    reportDto.Gender!.Value,
                    reportDto.Age!.Value,
                    reportDto.PersonDescription!,
                    reportDto.PersonState!.Value,
                    report.Id);

                // Add the missing person to the report
                report.AddMissingPerson(missingPerson);

                // Add single image for person if provided
                if (reportDto.Image != null && reportDto.Image.IsForPerson)
                {
                    missingPerson.AddImage(reportDto.Image.Path);
                }
            }
            // Add missing thing if applicable
            else if (reportDto.ReportSubjectType == ReportSubjectType.Thing)
            {
                // Create missing thing using factory method
                var missingThing = MissingThing.Create(
                    reportDto.ThingType!,
                    reportDto.ThingDescription!,
                    reportDto.ThingState!.Value,
                    report.Id);

                // Add the missing thing to the report
                report.AddMissingThing(missingThing);

                // Add single image for thing if provided
                if (reportDto.Image != null && !reportDto.Image.IsForPerson)
                {
                    missingThing.AddImage(reportDto.Image.Path);
                }
            }

            // Add the report to the context and save all changes
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Created complete report with ID: {ReportId}", report.Id);
            return Result<Guid>.Success(report.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating complete report");
            return Result<Guid>.Failure("Error creating complete report: " + ex.Message);
        }
    }

    public async Task<Result<IEnumerable<ReportDto>>> GetReportsAsync(
        ReportSubjectType? subjectType = null)
    {
        try
        {
            var query = _context.Reports
                .Include(r => r.Center)
                .Include(r => r.Government)
                .Include(r => r.User)
                .Include(r => r.MissingPerson)
                    .ThenInclude(mp => mp.Images)
                .Include(r => r.MissingThing)
                    .ThenInclude(mt => mt.Images)
                .Where(r => !r.IsDeleted && !r.IsHidden) // Exclude deleted and hidden reports
                .AsQueryable();

            if (subjectType.HasValue)
            {
                query = query.Where(r => r.ReportSubjectType == subjectType.Value);
            }

            var reports = await query.ToListAsync();
            return Result<IEnumerable<ReportDto>>.Success(reports.Select(x => ReportDto.FromEntity(x)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving reports");
            return Result<IEnumerable<ReportDto>>.Failure("Error retrieving reports: " + ex.Message);
        }
    }

    public async Task<Result<ReportDto>> GetReportByIdAsync(Guid reportId)
    {
        try
        {
            var report = await _context.Reports
                .Include(r => r.Center)
                .Include(r => r.Government)
                .Include(r => r.User)
                .Include(r => r.MissingPerson)
                    .ThenInclude(mp => mp.Images)
                .Include(r => r.MissingThing)
                    .ThenInclude(mt => mt.Images)
                .FirstOrDefaultAsync(r => r.Id == reportId && !r.IsDeleted); // Allow hidden but not deleted

            if (report == null)
            {
                return Result<ReportDto>.Failure("Report not found");
            }

            return Result<ReportDto>.Success(ReportDto.FromEntity(report));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving report {ReportId}", reportId);
            return Result<ReportDto>.Failure("Error retrieving report: " + ex.Message);
        }
    }

    // Also update the GetReportsByMissingStateAsync method
    public async Task<Result<IEnumerable<ReportDto>>> GetReportsByMissingStateAsync(MissingState? missingState = null)
    {
        try
        {
            var query = _context.Reports
                .Include(r => r.Center)
                .Include(r => r.Government)
                .Include(r => r.User)
                .Include(r => r.MissingPerson)
                    .ThenInclude(mp => mp.Images)
                .Where(r => r.ReportSubjectType == ReportSubjectType.Person) // Only include person reports
                .Where(r => !r.IsDeleted && !r.IsHidden) // Exclude deleted and hidden reports
                .AsQueryable();
    
            if (missingState.HasValue)
            {
                // Filter by missing state - only for missing persons
                query = query.Where(r => 
                    r.MissingPerson != null && 
                    r.MissingPerson.State == missingState.Value);
            }
    
            var reports = await query.ToListAsync();
            return Result<IEnumerable<ReportDto>>.Success(reports.Select(x => ReportDto.FromEntity(x)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving reports by missing state");
            return Result<IEnumerable<ReportDto>>.Failure("Error retrieving reports by missing state: " + ex.Message);
        }
    }

    public async Task<Result<IEnumerable<Center>>> GetAllCentersAsync()
    {
        try
        {
            var centers = await _context.Centers.ToListAsync();
            return Result<IEnumerable<Center>>.Success(centers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving centers");
            return Result<IEnumerable<Center>>.Failure("Error retrieving centers: " + ex.Message);
        }
    }

    // Add this method to the MissingPersonService class
    
    public async Task<Result<IEnumerable<CenterDto>>> GetCentersByGovernmentIdAsync(int governmentId)
    {
        try
        {
            // Verify the government exists
            var government = await _context.Governments.FindAsync(governmentId);
            if (government == null)
            {
                return Result<IEnumerable<CenterDto>>.Failure("Government not found");
            }
    
            // Get centers for the specified government
            var centers = await _context.Centers
                .Where(c => c.GovernmentId == governmentId)
                .Select(x=>new CenterDto { Id=x.Id,NameAr=x.NameAr,NameEn=x.NameEn})
                .ToListAsync();
                
            return Result<IEnumerable<CenterDto>>.Success(centers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving centers for government {GovernmentId}", governmentId);
            return Result<IEnumerable<CenterDto>>.Failure("Error retrieving centers: " + ex.Message);
        }
    }

    // Add this method to update a report with images after creation
    public async Task<Result<bool>> UpdateReportImagesAsync(Guid reportId, List<ImageDto> images)
    {
        try
        {
            var report = await _context.Reports
                .Include(r => r.MissingPerson)
                .Include(r => r.MissingThing)
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null)
            {
                return Result<bool>.Failure("Report not found");
            }

            // Add images based on the report subject type
            if (report.ReportSubjectType == ReportSubjectType.Person && report.MissingPerson != null)
            {
                foreach (var image in images.Where(i => i.IsForPerson))
                {
                    report.MissingPerson.AddImage(image.Path);
                }
            }
            else if (report.ReportSubjectType == ReportSubjectType.Thing && report.MissingThing != null)
            {
                foreach (var image in images.Where(i => !i.IsForPerson))
                {
                    report.MissingThing.AddImage(image.Path);
                }
            }

            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating report images for report {ReportId}", reportId);
            return Result<bool>.Failure("Error updating report images: " + ex.Message);
        }
    }

    // Add this method to update a report with a single image after creation
    public async Task<Result<bool>> UpdateReportImageAsync(Guid reportId, ImageDto image)
    {
        try
        {
            // First, determine if we're dealing with a person or thing report
            var report = await _context.Reports
                .AsNoTracking() // Use AsNoTracking to just get the type info without tracking
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null)
            {
                return Result<bool>.Failure("Report not found");
            }

            // Create the image entity directly
            if (report.ReportSubjectType == ReportSubjectType.Person && image.IsForPerson)
            {
                // Get the missing person ID
                var missingPersonId = await _context.MissingPersons
                    .Where(mp => mp.ReportId == reportId)
                    .Select(mp => mp.Id)
                    .FirstOrDefaultAsync();

                if (missingPersonId == Guid.Empty)
                {
                    return Result<bool>.Failure("Missing person not found for this report");
                }

                // Create and add the image directly
                var personImage = new MissingPersonImage
                {
                    MissingPersonId = missingPersonId,
                    ImagePath = image.Path
                };

                _context.MissingPersonImages.Add(personImage);
            }
            else if (report.ReportSubjectType == ReportSubjectType.Thing && !image.IsForPerson)
            {
                // Get the missing thing ID
                var missingThingId = await _context.MissingThings
                    .Where(mt => mt.ReportId == reportId)
                    .Select(mt => mt.Id)
                    .FirstOrDefaultAsync();

                if (missingThingId == Guid.Empty)
                {
                    return Result<bool>.Failure("Missing thing not found for this report");
                }

                // Create and add the image directly
                var thingImage = new MissingThingImage
                {
                    MissingThingId = missingThingId,
                    ImagePath = image.Path
                };

                _context.MissingThingImages.Add(thingImage);
            }
            else
            {
                return Result<bool>.Failure("Image type doesn't match report subject type");
            }
            
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating report image for report {ReportId}", reportId);
            return Result<bool>.Failure("Error updating report image: " + ex.Message);
        }
    }

    // ...

    public async Task<Result<bool>> HideReportAsync(Guid reportId)
    {
        try
        {
            var report = await _context.Reports.FindAsync(reportId);
            if (report == null)
            {
                return Result<bool>.Failure("Report not found");
            }

            report.IsHidden = true;
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Report with ID {ReportId} has been hidden", reportId);
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error hiding report {ReportId}", reportId);
            return Result<bool>.Failure("Error hiding report: " + ex.Message);
        }
    }

    public async Task<Result<bool>> DeleteReportAsync(Guid reportId)
    {
        try
        {
            var report = await _context.Reports.FindAsync(reportId);
            if (report == null)
            {
                return Result<bool>.Failure("Report not found");
            }

            report.IsDeleted = true;
            report.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Report with ID {ReportId} has been soft deleted", reportId);
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting report {ReportId}", reportId);
            return Result<bool>.Failure("Error deleting report: " + ex.Message);
        }
    }

    public async Task<Result<IEnumerable<ReportDto>>> GetArchivedReportsAsync()
    {
        try
        {
            var query = _context.Reports
                .Include(r => r.Center)
                .Include(r => r.Government)
                .Include(r => r.User)
                .Include(r => r.MissingPerson)
                    .ThenInclude(mp => mp.Images)
                .Include(r => r.MissingThing)
                    .ThenInclude(mt => mt.Images)
                .Where(r => r.IsDeleted)
                .AsQueryable();

            var reports = await query.ToListAsync();
            return Result<IEnumerable<ReportDto>>.Success(reports.Select(x => ReportDto.FromEntity(x)));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving archived reports");
            return Result<IEnumerable<ReportDto>>.Failure("Error retrieving archived reports: " + ex.Message);
        }
    }
}