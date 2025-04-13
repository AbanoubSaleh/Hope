namespace Hope.Application.Authentication.DTOs
{
    public class ExternalLoginDto
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }
}