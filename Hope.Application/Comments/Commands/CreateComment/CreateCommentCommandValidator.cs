using FluentValidation;

namespace Hope.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment content is required")
                .MaximumLength(1000).WithMessage("Comment content cannot exceed 1000 characters");
                
            RuleFor(x => x.ReportId)
                .NotEmpty().WithMessage("Report ID is required");
        }
    }
}