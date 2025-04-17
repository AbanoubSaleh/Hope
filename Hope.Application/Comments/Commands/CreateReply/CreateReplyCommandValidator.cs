using FluentValidation;

namespace Hope.Application.Comments.Commands.CreateReply
{
    public class CreateReplyCommandValidator : AbstractValidator<CreateReplyCommand>
    {
        public CreateReplyCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Reply content is required")
                .MaximumLength(1000).WithMessage("Reply content cannot exceed 1000 characters");
                
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("Comment ID is required");
        }
    }
}