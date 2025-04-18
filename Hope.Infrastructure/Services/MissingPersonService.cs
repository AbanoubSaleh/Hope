using Hope.Application.Comments.DTOs;
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
    public async Task<Result<PaginatedList<ReportDto>>> GetReportsByMissingStateAsync(
        MissingState? missingState = null,
        int pageNumber = 1,
        int pageSize = 10,
        bool includeComments = false)
    {
        try
        {
            var query = _context.Reports
                .Include(r => r.Center)
                .Include(r => r.Government)
                .Include(r => r.User)
                .Include(r => r.MissingPerson)
                    .ThenInclude(mp => mp.Images)
                .Where(r => r.ReportSubjectType == ReportSubjectType.Person)
                .Where(r => !r.IsDeleted && !r.IsHidden)
                .AsQueryable();

            if (missingState.HasValue)
            {
                query = query.Where(r =>
                    r.MissingPerson != null &&
                    r.MissingPerson.State == missingState.Value);
            }

            var totalCount = await query.CountAsync();

            var reports = await query
                .OrderByDescending(r => r.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var reportDtos = reports.Select(r => ReportDto.FromEntity(r)).ToList();

            if (includeComments)
            {
                foreach (var reportDto in reportDtos)
                {
                    var comments = await _context.Comments
                        .Where(c => c.ReportId == reportDto.Id && !c.IsDeleted)
                        .Include(c => c.User)
                        .Include(c => c.Replies.Where(r => !r.IsDeleted))
                        .ThenInclude(r => r.User)
                        .OrderByDescending(c => c.CreatedAt)
                        .ToListAsync();

                    reportDto.Comments = comments.Select(CommentDto.FromEntity).ToList();
                }
            }

            var paginatedList = new PaginatedList<ReportDto>(
                reportDtos,
                totalCount,
                pageNumber,
                pageSize);

            return Result<PaginatedList<ReportDto>>.Success(paginatedList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving reports by missing state");
            return Result<PaginatedList<ReportDto>>.Failure("Error retrieving reports by missing state: " + ex.Message);
        }
    }

    public async Task<Result<PaginatedList<ReportDto>>> GetArchivedReportsAsync(
        int pageNumber = 1,
        int pageSize = 10,
        bool includeComments = false)
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

            var totalCount = await query.CountAsync();

            var reports = await query
                .OrderByDescending(r => r.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var reportDtos = reports.Select(r => ReportDto.FromEntity(r)).ToList();

            if (includeComments)
            {
                foreach (var reportDto in reportDtos)
                {
                    var comments = await _context.Comments
                        .Where(c => c.ReportId == reportDto.Id && !c.IsDeleted)
                        .Include(c => c.User)
                        .Include(c => c.Replies.Where(r => !r.IsDeleted))
                        .ThenInclude(r => r.User)
                        .OrderByDescending(c => c.CreatedAt)
                        .ToListAsync();

                    reportDto.Comments = comments.Select(CommentDto.FromEntity).ToList();
                }
            }

            var paginatedList = new PaginatedList<ReportDto>(
                reportDtos,
                totalCount,
                pageNumber,
                pageSize);

            return Result<PaginatedList<ReportDto>>.Success(paginatedList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving archived reports");
            return Result<PaginatedList<ReportDto>>.Failure("Error retrieving archived reports: " + ex.Message);
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

    // Add this method to update a report with images after creation
    // Add this method to the MissingPersonService class
    
    public async Task<Result<bool>> UpdateReportAsync(UpdateReportDto updateDto)
    {
        try
        {
            // Validate all foreign keys first
            var center = await _context.Centers.FindAsync(updateDto.CenterId);
            if (center == null)
            {
                return Result<bool>.Failure("Center not found");
            }
    
            var government = await _context.Governments.FindAsync(updateDto.GovernmentId);
            if (government == null)
            {
                return Result<bool>.Failure("Government not found");
            }
    
            // Get the report with related entities
            var report = await _context.Reports
                .Include(r => r.MissingPerson)
                .Include(r => r.MissingThing)
                .FirstOrDefaultAsync(r => r.Id == updateDto.ReportId && !r.IsDeleted);
    
            if (report == null)
            {
                return Result<bool>.Failure("Report not found or has been deleted");
            }
    
            // Use domain method to update report properties
            report.UpdateReportDetails(
                updateDto.PhoneNumber,
                updateDto.IncidentTime,
                updateDto.ReportType,
                updateDto.CenterId,
                updateDto.GovernmentId
            );
    
            // Update missing person if applicable
            if (updateDto.ReportSubjectType == ReportSubjectType.Person)
            {
                if (report.MissingPerson == null)
                {
                    // Create missing person if it doesn't exist
                    var missingPerson = MissingPerson.Create(
                        updateDto.PersonName!,
                        updateDto.Gender!.Value,
                        updateDto.Age!.Value,
                        updateDto.PersonDescription!,
                        updateDto.PersonState!.Value,
                        report.Id);
    
                    report.AddMissingPerson(missingPerson);
                }
                else
                {
                    // Update existing missing person using domain method
                    report.MissingPerson.UpdateDetails(
                        updateDto.PersonName!,
                        updateDto.Gender!.Value,
                        updateDto.Age!.Value,
                        updateDto.PersonDescription!,
                        updateDto.PersonState!.Value
                    );
                }
            }
            // Update missing thing if applicable
            else if (updateDto.ReportSubjectType == ReportSubjectType.Thing)
            {
                if (report.MissingThing == null)
                {
                    // Create missing thing if it doesn't exist
                    var missingThing = MissingThing.Create(
                        updateDto.ThingType!,
                        updateDto.ThingDescription!,
                        updateDto.ThingState!.Value,
                        report.Id);
    
                    report.AddMissingThing(missingThing);
                }
                else
                {
                    // Update existing missing thing using domain method
                    report.MissingThing.UpdateDetails(
                        updateDto.ThingType!,
                        updateDto.ThingDescription!,
                        updateDto.ThingState!.Value
                    );
                }
            }
    
            // Save all changes
            await _context.SaveChangesAsync();
    
            _logger.LogInformation("Updated report with ID: {ReportId}", report.Id);
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating report {ReportId}", updateDto.ReportId);
            return Result<bool>.Failure("Error updating report: " + ex.Message);
        }
    }

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


    public async Task<Result<IEnumerable<CommentDto>>> GetReportCommentsAsync(Guid reportId)
    {
        try
        {
            // Check if report exists
            var report = await _context.Reports
                .FirstOrDefaultAsync(r => r.Id == reportId && !r.IsDeleted);
                
            if (report == null)
            {
                return Result<IEnumerable<CommentDto>>.Failure("Report not found or has been deleted");
            }
            
            // Get comments with replies
            var comments = await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Replies)
                    .ThenInclude(r => r.User)
                .Include(c => c.Replies)
                    .ThenInclude(r => r.ChildReplies)
                        .ThenInclude(cr => cr.User)
                .Where(c => c.ReportId == reportId && !c.IsDeleted)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
            
            var commentDtos = comments.Select(CommentDto.FromEntity).ToList();
            
            return Result<IEnumerable<CommentDto>>.Success(commentDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving comments for report {ReportId}", reportId);
            return Result<IEnumerable<CommentDto>>.Failure("Error retrieving comments: " + ex.Message);
        }
    }

    // Add this method to your existing MissingPersonService class
    public async Task<Result<PaginatedList<ReportDto>>> GetReportsAsync(
        int pageNumber, 
        int pageSize, 
        ReportSubjectType? reportSubjectType = null, 
        bool includeComments = false)
    {
        try
        {
            var query = _context.Reports
                .Where(r => !r.IsDeleted && !r.IsHidden)
                .AsQueryable();
    
            if (reportSubjectType.HasValue)
            {
                query = query.Where(r => r.ReportSubjectType == reportSubjectType.Value);
            }
    
            // Get total count for pagination
            var totalCount = await query.CountAsync();
    
            // Apply pagination
            var reports = await query
                .OrderByDescending(r => r.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(r => r.User)
                .Include(r => r.Government)
                .Include(r => r.Center)
                .Include(r => r.MissingThing)
                .ThenInclude(m=>m.Images)
                .Include(r => r.MissingPerson)
                .ThenInclude(mp => mp.Images)
                .ToListAsync();
    
            var reportDtos = reports.Select(r => ReportDto.FromEntity(r)).ToList();
    
            // Include comments if requested
            if (includeComments)
            {
                foreach (var reportDto in reportDtos)
                {
                    var comments = await _context.Comments
                        .Where(c => c.ReportId == reportDto.Id && !c.IsDeleted)
                        .Include(c => c.User)
                        .Include(c => c.Replies.Where(r => !r.IsDeleted))
                        .ThenInclude(r => r.User)
                        .OrderByDescending(c => c.CreatedAt)
                        .ToListAsync();
    
                    reportDto.Comments = comments.Select(CommentDto.FromEntity).ToList();
                }
            }
    
            var paginatedList = new PaginatedList<ReportDto>(
                reportDtos, 
                totalCount, 
                pageNumber, 
                pageSize);
    
            return Result<PaginatedList<ReportDto>>.Success(paginatedList);
        }
        catch (Exception ex)
        {
            return Result<PaginatedList<ReportDto>>.Failure($"Error retrieving reports: {ex.Message}");
        }
    }
}