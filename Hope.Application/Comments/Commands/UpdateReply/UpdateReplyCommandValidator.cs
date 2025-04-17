using FluentValidation;

namespace Hope.Application.Comments.Commands.UpdateReply
{
    public class UpdateReplyCommandValidator : AbstractValidator<UpdateReplyCommand>
    {
        public UpdateReplyCommandValidator()
        {
            RuleFor(x => x.ReplyId)
                .NotEmpty().WithMessage("Reply ID is required");
                
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Reply content is required")
                .MaximumLength(1000).WithMessage("Reply content cannot exceed 1000 characters");
        }
    }
}