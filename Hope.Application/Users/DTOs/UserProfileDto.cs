using Hope.Application.LookUps.Dtos;
using Hope.Application.MissingPerson.DTOs;
using System;
using System.Collections.Generic;

namespace Hope.Application.Users.DTOs
{
    public class UserProfileDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public GovernmentDto? Government { get; set; }
        public List<ReportDto> Reports { get; set; } = new List<ReportDto>();
    }
}