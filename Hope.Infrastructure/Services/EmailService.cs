using Hope.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace Hope.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            try
            {
                var smtpServer = _configuration["Email:SmtpServer"];
                var smtpPort = int.Parse(_configuration["Email:SmtpPort"]);
                var smtpUsername = _configuration["Email:SmtpUsername"];
                var smtpPassword = _configuration["Email:SmtpPassword"];
                var fromEmail = _configuration["Email:FromEmail"];
                var fromName = _configuration["Email:FromName"];

                using var client = new SmtpClient(smtpServer, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true,
                    Host = "smtp.gmail.com", // Gmail SMTP server
                    Port = 587, // Port for TLS
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail, fromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Email sent to {To} with subject {Subject}", to, subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {To} with subject {Subject}", to, subject);
                throw;
            }
        }

        public async Task SendEmailConfirmationAsync(string email, string callbackUrl)
        {
            var subject = "Confirm your email";
            var body = $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .button {{ display: inline-block; padding: 10px 20px; background-color: #007bff; color: white; text-decoration: none; border-radius: 4px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>Confirm Your Email Address</h2>
                        <p>Thank you for registering with us. Please confirm your email address by clicking the button below:</p>
                        <p><a href='{callbackUrl}' class='button'>Confirm Email</a></p>
                        <p>If you did not request this email, please ignore it.</p>
                        <p>If the button doesn't work, copy and paste the following link into your browser:</p>
                        <p>{callbackUrl}</p>
                    </div>
                </body>
                </html>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetAsync(string email, string callbackUrl)
        {
            var subject = "Reset your password";
            var body = $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .button {{ display: inline-block; padding: 10px 20px; background-color: #007bff; color: white; text-decoration: none; border-radius: 4px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>Reset Your Password</h2>
                        <p>You requested a password reset. Please click the button below to reset your password:</p>
                        <p><a href='{callbackUrl}' class='button'>Reset Password</a></p>
                        <p>If you did not request this email, please ignore it.</p>
                        <p>If the button doesn't work, copy and paste the following link into your browser:</p>
                        <p>{callbackUrl}</p>
                    </div>
                </body>
                </html>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendEmailConfirmationCodeAsync(string to, string confirmationCode)
        {
            var subject = "Confirm your email address";
            var body = $@"
                <h1>Welcome to Hope!</h1>
                <p>Thank you for registering. Please confirm your email address by entering the following code:</p>
                <h2 style='background-color: #f5f5f5; padding: 10px; text-align: center; font-size: 24px;'>{confirmationCode}</h2>
                <p>This code will expire in 24 hours.</p>
                <p>If you did not request this email, please ignore it.</p>
            ";
            
            await SendEmailAsync(to, subject, body);
        }


    }
}