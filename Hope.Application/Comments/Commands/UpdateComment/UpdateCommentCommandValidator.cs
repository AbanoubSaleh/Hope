using FluentValidation;

namespace Hope.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("Comment ID is required");
                
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment content is required")
                .MaximumLength(1000).WithMessage("Comment content cannot exceed 1000 characters");
        }
    }
}