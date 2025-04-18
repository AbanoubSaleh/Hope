using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Hope.Application.MissingPerson.Queries.FindReportByFace
{
    public class FindReportByFaceQuery : IRequest<Result<ReportDto>>
    {
        public IFormFile? ImageFile { get; set; }
    }
}