using Hope.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hope.Infrastructure.Persistence.Seeding
{
    public static class GovernmentSeeder
    {
        public static void SeedGovernments(this ModelBuilder modelBuilder)
        {
            var governments = new List<Government>
            {
                new Government { Id = 1, NameEn = "Cairo", NameAr = "القاهرة", PhoneCode = "02" },
                new Government { Id = 2, NameEn = "Alexandria", NameAr = "الإسكندرية", PhoneCode = "03" },
                new Government { Id = 3, NameEn = "Giza", NameAr = "الجيزة", PhoneCode = "02" },
                new Government { Id = 4, NameEn = "Qalyubia", NameAr = "القليوبية", PhoneCode = "013" },
                new Government { Id = 5, NameEn = "Port Said", NameAr = "بورسعيد", PhoneCode = "066" },
                new Government { Id = 6, NameEn = "Suez", NameAr = "السويس", PhoneCode = "062" },
                new Government { Id = 7, NameEn = "Luxor", NameAr = "الأقصر", PhoneCode = "095" },
                new Government { Id = 8, NameEn = "Aswan", NameAr = "أسوان", PhoneCode = "097" },
                new Government { Id = 9, NameEn = "Assiut", NameAr = "أسيوط", PhoneCode = "088" },
                new Government { Id = 10, NameEn = "Beheira", NameAr = "البحيرة", PhoneCode = "045" },
                new Government { Id = 11, NameEn = "Beni Suef", NameAr = "بني سويف", PhoneCode = "082" },
                new Government { Id = 12, NameEn = "Dakahlia", NameAr = "الدقهلية", PhoneCode = "050" },
                new Government { Id = 13, NameEn = "Damietta", NameAr = "دمياط", PhoneCode = "057" },
                new Government { Id = 14, NameEn = "Faiyum", NameAr = "الفيوم", PhoneCode = "084" },
                new Government { Id = 15, NameEn = "Gharbia", NameAr = "الغربية", PhoneCode = "040" },
                new Government { Id = 16, NameEn = "Ismailia", NameAr = "الإسماعيلية", PhoneCode = "064" },
                new Government { Id = 17, NameEn = "Kafr El Sheikh", NameAr = "كفر الشيخ", PhoneCode = "047" },
                new Government { Id = 18, NameEn = "Matruh", NameAr = "مطروح", PhoneCode = "046" },
                new Government { Id = 19, NameEn = "Minya", NameAr = "المنيا", PhoneCode = "086" },
                new Government { Id = 20, NameEn = "Monufia", NameAr = "المنوفية", PhoneCode = "048" },
                new Government { Id = 21, NameEn = "New Valley", NameAr = "الوادي الجديد", PhoneCode = "092" },
                new Government { Id = 22, NameEn = "North Sinai", NameAr = "شمال سيناء", PhoneCode = "068" },
                new Government { Id = 23, NameEn = "Qena", NameAr = "قنا", PhoneCode = "096" },
                new Government { Id = 24, NameEn = "Red Sea", NameAr = "البحر الأحمر", PhoneCode = "065" },
                new Government { Id = 25, NameEn = "Sharqia", NameAr = "الشرقية", PhoneCode = "055" },
                new Government { Id = 26, NameEn = "Sohag", NameAr = "سوهاج", PhoneCode = "093" },
                new Government { Id = 27, NameEn = "South Sinai", NameAr = "جنوب سيناء", PhoneCode = "069" }
            };

            modelBuilder.Entity<Government>().HasData(governments);
        }
    }
}