using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Application.MissingPerson.Queries.GetReportById;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Queries.FindReportByFace
{
    public class FindReportByFaceQueryHandler : IRequestHandler<FindReportByFaceQuery, Result<ReportDto>>
    {
        private readonly IFaceRecognitionService _faceRecognitionService;
        private readonly IMediator _mediator;

        public FindReportByFaceQueryHandler(
            IFaceRecognitionService faceRecognitionService,
            IMediator mediator)
        {
            _faceRecognitionService = faceRecognitionService;
            _mediator = mediator;
        }

        public async Task<Result<ReportDto>> Handle(FindReportByFaceQuery request, CancellationToken cancellationToken)
        {
            // Step 1: Use face recognition service to find a match
            var matchResult = await _faceRecognitionService.FindMatchingFaceAsync(request.ImageFile);

            if (!matchResult.Succeeded)
            {
                return Result<ReportDto>.Failure(matchResult.Message);
            }

            // Step 2: If no match found, return appropriate message
            if (matchResult.Data == null)
            {
                return Result<ReportDto>.Success(null, "No matching face found. Please consider creating a new missing person report.");
            }

            // Step 3: If match found, get the report details
            var reportId = matchResult.Data.Value;
            var query = new GetReportByIdQuery { ReportId = reportId };
            var reportResult = await _mediator.Send(query, cancellationToken);

            if (!reportResult.Succeeded)
            {
                return Result<ReportDto>.Failure($"Face match found but error retrieving report: {reportResult.Message}");
            }

            return Result<ReportDto>.Success(reportResult.Data, "Matching person found in our records.");
        }
    }
}