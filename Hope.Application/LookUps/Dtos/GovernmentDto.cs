using Hope.Domain.Entities;

namespace Hope.Application.LookUps.Dtos
{
    public class GovernmentDto
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!;
        public string PhoneCode { get; set; } = null!;
        public static GovernmentDto FromEntity(Government government)
        {
            return new GovernmentDto
            {
                Id = government.Id,
                NameEn = government.NameEn,
                NameAr = government.NameAr,
                PhoneCode = government.PhoneCode
            };
        }
    }
}