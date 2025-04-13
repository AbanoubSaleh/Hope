namespace Hope.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
        Task SendEmailConfirmationAsync(string email, string callbackUrl);
        Task SendPasswordResetAsync(string email, string callbackUrl);
    }
}