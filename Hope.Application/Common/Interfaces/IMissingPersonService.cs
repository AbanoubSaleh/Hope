using Hope.Application.Common.Models;
using Hope.Application.LookUps.Dtos;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// Add this to the existing interface
using Hope.Application.Comments.DTOs;

namespace Hope.Application.Common.Interfaces
{
    public interface IMissingPersonService
    {
        // New method using DTO
        Task<Result<Guid>> CreateCompleteReportAsync(CreateReportDto reportDto);
            
        // Add this method to the existing interface
        Task<Result<PaginatedList<ReportDto>>> GetReportsAsync(
            int pageNumber, 
            int pageSize, 
            ReportSubjectType? reportSubjectType = null, 
            bool includeComments = false);
            
        Task<Result<ReportDto>> GetReportByIdAsync(Guid reportId);
        
        Task<Result<IEnumerable<Center>>> GetAllCentersAsync();
        
        // New method to get centers by government ID
        Task<Result<IEnumerable<CenterDto>>> GetCentersByGovernmentIdAsync(int governmentId);
        
        Task<Result<bool>> UpdateReportImageAsync(Guid reportId, ImageDto image);
        
        // New method to get reports by missing state
        Task<Result<PaginatedList<ReportDto>>> GetReportsByMissingStateAsync(
            MissingState? missingState = null,
            int pageNumber = 1,
            int pageSize = 10,
            bool includeComments = false);
        
        // New methods for hiding, deleting, and retrieving archived reports
        Task<Result<bool>> HideReportAsync(Guid reportId);
        
        Task<Result<bool>> DeleteReportAsync(Guid reportId);
        
        Task<Result<PaginatedList<ReportDto>>> GetArchivedReportsAsync(
            int pageNumber = 1,
            int pageSize = 10,
            bool includeComments = false);
        
        // New method for updating reports
        Task<Result<bool>> UpdateReportAsync(UpdateReportDto updateDto);
        
        // New methods for comments
        Task<Result<IEnumerable<CommentDto>>> GetReportCommentsAsync(Guid reportId);
    }
}