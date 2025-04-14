using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hope.Infrastructure.Services;

public class MissingPersonService : IMissingPersonService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<MissingPersonService> _logger;

    public MissingPersonService(ApplicationDbContext context, ILogger<MissingPersonService> logger)
    {
        _context = context;
        _logger = logger;
    }

    // Updated method using DTO
    public async Task<Result<Guid>> CreateCompleteReportAsync(CreateReportDto reportDto)
    {
        try
        {
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
                reportDto.GovernmentId);

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

                // Add images for person if provided
                if (reportDto.Images != null)
                {
                    foreach (var image in reportDto.Images.Where(i => i.IsForPerson))
                    {
                        missingPerson.AddImage(image.Path);
                    }
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

                // Add images for thing if provided
                if (reportDto.Images != null)
                {
                    foreach (var image in reportDto.Images.Where(i => !i.IsForPerson))
                    {
                        missingThing.AddImage(image.Path);
                    }
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

    public async Task<Result<IEnumerable<Report>>> GetReportsAsync(
        ReportType? reportType = null, 
        ReportSubjectType? subjectType = null)
    {
        try
        {
            var query = _context.Reports
                .Include(r => r.Center)
                .Include(r => r.Government)
                .Include(r => r.MissingPerson)
                    .ThenInclude(mp => mp.Images)
                .AsQueryable();

            if (reportType.HasValue)
            {
                query = query.Where(r => r.ReportType == reportType.Value);
            }

            if (subjectType.HasValue)
            {
                query = query.Where(r => r.ReportSubjectType == subjectType.Value);
            }

            var reports = await query.ToListAsync();
            return Result<IEnumerable<Report>>.Success(reports);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving reports");
            return Result<IEnumerable<Report>>.Failure("Error retrieving reports: " + ex.Message);
        }
    }

    public async Task<Result<Report>> GetReportByIdAsync(Guid reportId)
    {
        try
        {
            var report = await _context.Reports
                .Include(r => r.Center)
                .Include(r => r.Government)
                .Include(r => r.MissingPerson)
                    .ThenInclude(mp => mp.Images)
                .FirstOrDefaultAsync(r => r.Id == reportId);

            if (report == null)
            {
                return Result<Report>.Failure("Report not found");
            }

            return Result<Report>.Success(report);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving report {ReportId}", reportId);
            return Result<Report>.Failure("Error retrieving report: " + ex.Message);
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
    
    public async Task<Result<IEnumerable<Center>>> GetCentersByGovernmentIdAsync(int governmentId)
    {
        try
        {
            // Verify the government exists
            var government = await _context.Governments.FindAsync(governmentId);
            if (government == null)
            {
                return Result<IEnumerable<Center>>.Failure("Government not found");
            }
    
            // Get centers for the specified government
            var centers = await _context.Centers
                .Where(c => c.GovernmentId == governmentId)
                .ToListAsync();
                
            return Result<IEnumerable<Center>>.Success(centers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving centers for government {GovernmentId}", governmentId);
            return Result<IEnumerable<Center>>.Failure("Error retrieving centers: " + ex.Message);
        }
    }
}