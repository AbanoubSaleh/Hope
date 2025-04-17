using FluentValidation;

namespace Hope.Application.Comments.Commands.DeleteReply
{
    public class DeleteReplyCommandValidator : AbstractValidator<DeleteReplyCommand>
    {
        public DeleteReplyCommandValidator()
        {
            RuleFor(x => x.ReplyId)
                .NotEmpty().WithMessage("Reply ID is required");
        }
    }
}