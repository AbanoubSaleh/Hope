namespace Hope.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
        Task SendEmailConfirmationAsync(string to, string callbackUrl);
        Task SendPasswordResetAsync(string to, string callbackUrl);
        
        // New method for sending confirmation code
        Task SendEmailConfirmationCodeAsync(string to, string confirmationCode);
    }
}