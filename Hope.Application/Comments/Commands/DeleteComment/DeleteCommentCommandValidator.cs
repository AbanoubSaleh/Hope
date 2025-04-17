using FluentValidation;

namespace Hope.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty().WithMessage("Comment ID is required");
        }
    }
}