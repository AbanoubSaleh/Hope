using Hope.Application.Common.Models;
using Hope.Application.LookUps.Dtos;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface IMissingPersonService
    {
        // New method using DTO
        Task<Result<Guid>> CreateCompleteReportAsync(CreateReportDto reportDto);
            
        Task<Result<IEnumerable<ReportDto>>> GetReportsAsync(          
            ReportSubjectType? subjectType = null);
            
        Task<Result<ReportDto>> GetReportByIdAsync(Guid reportId);
        
        Task<Result<IEnumerable<Center>>> GetAllCentersAsync();
        
        // New method to get centers by government ID
        Task<Result<IEnumerable<CenterDto>>> GetCentersByGovernmentIdAsync(int governmentId);
        
        Task<Result<bool>> UpdateReportImageAsync(Guid reportId, ImageDto image);
    }
}