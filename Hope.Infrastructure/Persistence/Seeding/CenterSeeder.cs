using Hope.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hope.Infrastructure.Persistence.Seeding;

public static class CenterSeeder
{
    public static void SeedCenters(this ModelBuilder modelBuilder)
    {
        var centers = new List<Center>();

        // Cairo (1)
        AddCentersForGovernment(centers, 1, new[] {
            ("Maadi", "المعادي"),
            ("Nasr City", "مدينة نصر"),
            ("Heliopolis", "مصر الجديدة"),
            ("Downtown", "وسط البلد"),
            ("Zamalek", "الزمالك"),
            ("Shubra", "شبرا"),
            ("El Matareya", "المطرية"),
            ("Ain Shams", "عين شمس"),
            ("El Marg", "المرج"),
            ("15th of May City", "مدينة 15 مايو")
        });

        // Alexandria (2)
        AddCentersForGovernment(centers, 2, new[] {
            ("Montazah", "المنتزه"),
            ("Sidi Gaber", "سيدي جابر"),
            ("Smouha", "سموحة"),
            ("Miami", "ميامي"),
            ("Agami", "العجمي"),
            ("Borg El Arab", "برج العرب"),
            ("Bahary", "بحري"),
            ("El Gomrok", "الجمرك"),
            ("El Dekhela", "الدخيلة"),
            ("Amreya", "العامرية")
        });

        // Giza (3)
        AddCentersForGovernment(centers, 3, new[] {
            ("Dokki", "الدقي"),
            ("Mohandessin", "المهندسين"),
            ("6th of October", "السادس من أكتوبر"),
            ("Sheikh Zayed", "الشيخ زايد"),
            ("Haram", "الهرم"),
            ("Faisal", "فيصل"),
            ("Agouza", "العجوزة"),
            ("Imbaba", "إمبابة"),
            ("Bulaq El Dakrour", "بولاق الدكرور"),
            ("Kerdasa", "كرداسة")
        });

        // Qalyubia (4)
        AddCentersForGovernment(centers, 4, new[] {
            ("Banha", "بنها"),
            ("Shubra El Kheima", "شبرا الخيمة"),
            ("Qalyub", "قليوب"),
            ("El Khanka", "الخانكة"),
            ("Kafr Shukr", "كفر شكر"),
            ("Qaha", "قها"),
            ("Tukh", "طوخ"),
            ("El Qanater El Khayreya", "القناطر الخيرية"),
            ("Shibin El Qanater", "شبين القناطر"),
            ("Obour City", "مدينة العبور")
        });

        // Port Said (5)
        AddCentersForGovernment(centers, 5, new[] {
            ("Port Said City", "مدينة بورسعيد"),
            ("Port Fouad", "بور فؤاد"),
            ("El Manakh", "المناخ"),
            ("El Dawahy", "الضواحي"),
            ("El Arab", "العرب"),
            ("El Zohour", "الزهور"),
            ("El Sharq", "الشرق"),
            ("El Ganoub", "الجنوب"),
            ("El Gharb", "الغرب"),
            ("El Manasra", "المناصرة")
        });

        // Suez (6)
        AddCentersForGovernment(centers, 6, new[] {
            ("Suez City", "مدينة السويس"),
            ("Arbaeen", "الأربعين"),
            ("Ganayen", "الجناين"),
            ("Attaka", "عتاقة"),
            ("Faisal", "فيصل"),
            ("El Suez", "السويس"),
            ("Port Tawfik", "بورتوفيق"),
            ("El Salam", "السلام"),
            ("El Amal", "الأمل"),
            ("El Ganayen", "الجناين")
        });

        // Luxor (7)
        AddCentersForGovernment(centers, 7, new[] {
            ("Luxor City", "مدينة الأقصر"),
            ("Karnak", "الكرنك"),
            ("New Tiba", "طيبة الجديدة"),
            ("Armant", "أرمنت"),
            ("Esna", "إسنا"),
            ("El Zeiniya", "الزينية"),
            ("El Bayadiya", "البياضية"),
            ("El Qurna", "القرنة"),
            ("El Tod", "الطود"),
            ("El Tud", "الطود")
        });

        // Aswan (8)
        AddCentersForGovernment(centers, 8, new[] {
            ("Aswan City", "مدينة أسوان"),
            ("Kom Ombo", "كوم أمبو"),
            ("Edfu", "إدفو"),
            ("Daraw", "دراو"),
            ("Nasr Al Nuba", "نصر النوبة"),
            ("Kalabsha", "كلابشة"),
            ("Abu Simbel", "أبو سمبل"),
            ("El Basaliya", "البصيلية"),
            ("El Sibaiya", "السباعية"),
            ("Radisiya", "الرديسية")
        });

        // Assiut (9)
        AddCentersForGovernment(centers, 9, new[] {
            ("Assiut City", "مدينة أسيوط"),
            ("Dairut", "ديروط"),
            ("Manfalut", "منفلوط"),
            ("Abnub", "أبنوب"),
            ("El Qusiya", "القوصية"),
            ("Abnoub", "أبنوب"),
            ("El Badari", "البداري"),
            ("Sahel Selim", "ساحل سليم"),
            ("El Ghanayem", "الغنايم"),
            ("El Fath", "الفتح")
        });

        // Beheira (10)
        AddCentersForGovernment(centers, 10, new[] {
            ("Damanhour", "دمنهور"),
            ("Kafr El Dawwar", "كفر الدوار"),
            ("Rashid", "رشيد"),
            ("Edko", "إدكو"),
            ("Abu Hummus", "أبو حمص"),
            ("Hosh Issa", "حوش عيسى"),
            ("Shubrakhit", "شبراخيت"),
            ("Rahmaniya", "الرحمانية"),
            ("Itay El Barud", "إيتاي البارود"),
            ("Mahmoudiyah", "المحمودية")
        });

        // Continue with the remaining governments...
        // Beni Suef (11) through South Sinai (27)

        // Beni Suef (11)
        AddCentersForGovernment(centers, 11, new[] {
            ("Beni Suef City", "مدينة بني سويف"),
            ("El Wasta", "الواسطى"),
            ("Naser", "ناصر"),
            ("Ihnasia", "إهناسيا"),
            ("Beba", "ببا"),
            ("Sumusta", "سمسطا"),
            ("El Fashn", "الفشن"),
            ("New Beni Suef", "بني سويف الجديدة"),
            ("Ahnasia", "أهناسيا"),
            ("El Fashn", "الفشن")
        });

        // Dakahlia (12)
        AddCentersForGovernment(centers, 12, new[] {
            ("Mansoura", "المنصورة"),
            ("Talkha", "طلخا"),
            ("Mit Ghamr", "ميت غمر"),
            ("Aga", "أجا"),
            ("Sherbin", "شربين"),
            ("Bilqas", "بلقاس"),
            ("Dikirnis", "دكرنس"),
            ("El Sinbillawein", "السنبلاوين"),
            ("El Manzala", "المنزلة"),
            ("Mit Salsil", "ميت سلسيل")
        });

        // Damietta (13)
        AddCentersForGovernment(centers, 13, new[] {
            ("Damietta City", "مدينة دمياط"),
            ("New Damietta", "دمياط الجديدة"),
            ("Ras El Bar", "رأس البر"),
            ("Faraskour", "فارسكور"),
            ("Kafr Saad", "كفر سعد"),
            ("El Zarqa", "الزرقا"),
            ("Kafr El Batikh", "كفر البطيخ"),
            ("Ezbet El Borg", "عزبة البرج"),
            ("Mit Abou Ghaleb", "ميت أبو غالب"),
            ("El Rouda", "الروضة")
        });

        // Add the remaining governments...

        // Faiyum (14)
        AddCentersForGovernment(centers, 14, new[] {
            ("Fayoum City", "مدينة الفيوم"),
            ("Sinnuris", "سنورس"),
            ("Tamiya", "طامية"),
            ("Youssef El Seddik", "يوسف الصديق"),
            ("Etsa", "إطسا"),
            ("Ibsheway", "إبشواي"),
            ("New Fayoum", "الفيوم الجديدة"),
            ("Sanhur", "سنهور"),
            ("Abshaway", "أبشواي"),
            ("Manshiet Sabri", "منشية صبري")
        });

        // Gharbia (15)
        AddCentersForGovernment(centers, 15, new[] {
            ("Tanta", "طنطا"),
            ("El Mahalla El Kubra", "المحلة الكبرى"),
            ("Kafr El Zayat", "كفر الزيات"),
            ("Zefta", "زفتى"),
            ("El Santa", "السنطة"),
            ("Bassioun", "بسيون"),
            ("Samannoud", "سمنود"),
            ("Kotour", "قطور"),
            ("Tala", "طلا"),
            ("Nasr City", "مدينة نصر")
        });

        // Ismailia (16)
        AddCentersForGovernment(centers, 16, new[] {
            ("Ismailia City", "مدينة الإسماعيلية"),
            ("Fayed", "فايد"),
            ("El Tal El Kabir", "التل الكبير"),
            ("El Qantara", "القنطرة"),
            ("Abu Suwair", "أبو صوير"),
            ("El Qantara East", "القنطرة شرق"),
            ("El Qantara West", "القنطرة غرب"),
            ("El Kasasin", "القصاصين"),
            ("Nefisha", "نفيشة"),
            ("El Salam", "السلام")
        });

        // Kafr El Sheikh (17)
        AddCentersForGovernment(centers, 17, new[] {
            ("Kafr El Sheikh City", "مدينة كفر الشيخ"),
            ("Desouk", "دسوق"),
            ("Baltim", "بلطيم"),
            ("Qallin", "قلين"),
            ("Sidi Salem", "سيدي سالم"),
            ("Riyadh", "الرياض"),
            ("Metoubes", "مطوبس"),
            ("Fouh", "فوه"),
            ("Biala", "بيلا"),
            ("Hamoul", "الحامول")
        });

        // Matruh (18)
        AddCentersForGovernment(centers, 18, new[] {
            ("Marsa Matrouh", "مرسى مطروح"),
            ("El Alamein", "العلمين"),
            ("El Dabaa", "الضبعة"),
            ("El Hamam", "الحمام"),
            ("Sidi Barrani", "سيدي براني"),
            ("Salloum", "السلوم"),
            ("Siwa", "سيوة"),
            ("El Negila", "النجيلة"),
            ("Sidi Abdel Rahman", "سيدي عبد الرحمن"),
            ("Fuka", "فوكة")
        });

        // Minya (19)
        AddCentersForGovernment(centers, 19, new[] {
            ("Minya City", "مدينة المنيا"),
            ("Mallawi", "ملوي"),
            ("Samalut", "سمالوط"),
            ("Abu Qurqas", "أبو قرقاص"),
            ("Beni Mazar", "بني مزار"),
            ("Deir Mawas", "دير مواس"),
            ("Maghagha", "مغاغة"),
            ("Matay", "مطاي"),
            ("El Adwa", "العدوة"),
            ("New Minya", "المنيا الجديدة")
        });

        // Monufia (20)
        AddCentersForGovernment(centers, 20, new[] {
            ("Shebin El Kom", "شبين الكوم"),
            ("Ashmoun", "أشمون"),
            ("Menouf", "منوف"),
            ("Sadat City", "مدينة السادات"),
            ("Sers El Lyan", "سرس الليان"),
            ("Quesna", "قويسنا"),
            ("Berket El Sab", "بركة السبع"),
            ("Tala", "تلا"),
            ("Bagour", "باجور"),
            ("Shohadaa", "الشهداء")
        });

        // New Valley (21)
        AddCentersForGovernment(centers, 21, new[] {
            ("Kharga", "الخارجة"),
            ("Dakhla", "الداخلة"),
            ("Farafra", "الفرافرة"),
            ("Baris", "باريس"),
            ("Balat", "بلاط"),
            ("Mut", "موط"),
            ("El Qasr", "القصر"),
            ("Paris", "باريس"),
            ("Bashendi", "بشندي"),
            ("Mout", "موط")
        });

        // North Sinai (22)
        AddCentersForGovernment(centers, 22, new[] {
            ("El Arish", "العريش"),
            ("Sheikh Zuweid", "الشيخ زويد"),
            ("Rafah", "رفح"),
            ("Bir al-Abed", "بئر العبد"),
            ("El Hasana", "الحسنة"),
            ("Nakhl", "نخل"),
            ("Nekhel", "نخل"),
            ("Bir El Abd", "بئر العبد"),
            ("El Qantara East", "القنطرة شرق"),
            ("El Massaeed", "المساعيد")
        });

        // Qena (23)
        AddCentersForGovernment(centers, 23, new[] {
            ("Qena City", "مدينة قنا"),
            ("Nag Hammadi", "نجع حمادي"),
            ("Dishna", "دشنا"),
            ("Qift", "قفط"),
            ("Naqada", "نقادة"),
            ("Abu Tesht", "أبو تشت"),
            ("Farshout", "فرشوط"),
            ("Qus", "قوص"),
            ("Waqf", "الوقف"),
            ("Armant", "أرمنت")
        });

        // Red Sea (24)
        AddCentersForGovernment(centers, 24, new[] {
            ("Hurghada", "الغردقة"),
            ("Ras Gharib", "رأس غارب"),
            ("Safaga", "سفاجا"),
            ("El Quseir", "القصير"),
            ("Marsa Alam", "مرسى علم"),
            ("Shalatin", "شلاتين"),
            ("Halayeb", "حلايب"),
            ("El Gouna", "الجونة"),
            ("Makadi Bay", "خليج مكادي"),
            ("Sahl Hasheesh", "سهل حشيش")
        });

        // Sohag (26)
        AddCentersForGovernment(centers, 26, new[] {
            ("Sohag City", "مدينة سوهاج"),
            ("Akhmim", "أخميم"),
            ("El Balyana", "البلينا"),
            ("El Maragha", "المراغة"),
            ("Dar El Salam", "دار السلام"),
            ("Gerga", "جرجا"),
            ("Juhayna", "جهينة"),
            ("Sakulta", "ساقلتة"),
            ("Tahta", "طهطا"),
            ("Tima", "طما")
        });

        // South Sinai (27)
        AddCentersForGovernment(centers, 27, new[] {
            ("Sharm El Sheikh", "شرم الشيخ"),
            ("Dahab", "دهب"),
            ("Nuweiba", "نويبع"),
            ("Taba", "طابا"),
            ("Saint Catherine", "سانت كاترين"),
            ("Ras Sidr", "رأس سدر"),
            ("El Tor", "الطور"),
            ("Abu Zenima", "أبو زنيمة"),
            ("Abu Rudeis", "أبو رديس"),
            ("Naama Bay", "خليج نعمة")
        });

        modelBuilder.Entity<Center>().HasData(centers);
    }

    private static void AddCentersForGovernment(List<Center> centers, int governmentId, (string NameEn, string NameAr)[] centerNames)
    {
        // Starting seed for generating deterministic GUIDs for each government
        var guidCounter = governmentId * 100;

        foreach (var (nameEn, nameAr) in centerNames)
        {
            // Create a deterministic GUID based on the government ID and a counter
            var deterministicGuid = CreateDeterministicGuid($"Center_{governmentId}_{guidCounter}");
            guidCounter++;

            centers.Add(new Center
            {
                Id = deterministicGuid,
                NameEn = nameEn,
                NameAr = nameAr,
                GovernmentId = governmentId
            });
        }
    }

    // Helper method to create deterministic GUIDs based on a string
    private static Guid CreateDeterministicGuid(string input)
    {
        // Use MD5 to generate a hash from the input string
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            // Convert the first 16 bytes of the hash to a GUID
            return new Guid(hashBytes);
        }
    }
}