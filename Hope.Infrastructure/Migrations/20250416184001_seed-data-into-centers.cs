using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddataintocenters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Centers",
                columns: new[] { "Id", "GovernmentId", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { new Guid("00e1b730-138c-68aa-527a-300b835bf7a5"), 19, "بني مزار", "Beni Mazar" },
                    { new Guid("0185f125-9ad7-4e75-76cc-719e8b14c1b2"), 5, "بور فؤاد", "Port Fouad" },
                    { new Guid("0197bb9d-6292-9527-a3d3-50792f58fe53"), 16, "القنطرة غرب", "El Qantara West" },
                    { new Guid("01a24b39-8139-8ccc-af7d-a81457c9020f"), 5, "مدينة بورسعيد", "Port Said City" },
                    { new Guid("02b18049-769f-a8af-199f-ba23e04fdf43"), 6, "مدينة السويس", "Suez City" },
                    { new Guid("02b68222-9951-8111-4bb8-28459ff986e4"), 22, "العريش", "El Arish" },
                    { new Guid("0752bb4d-4b27-a26e-7a9b-6cc587a29634"), 26, "ساقلتة", "Sakulta" },
                    { new Guid("09f29961-2064-f049-df83-e1144b0c35b0"), 9, "الغنايم", "El Ghanayem" },
                    { new Guid("0a63e97b-4d62-bcb4-3fe0-fc8baacaec38"), 24, "سهل حشيش", "Sahl Hasheesh" },
                    { new Guid("0b4cc371-3906-bf69-d62c-9646f3440cb3"), 4, "القناطر الخيرية", "El Qanater El Khayreya" },
                    { new Guid("0ba9618a-3b26-6e12-f2a2-3463101fe980"), 12, "ميت سلسيل", "Mit Salsil" },
                    { new Guid("0bd817cf-4521-8f2a-0e2f-9d04a4c375bd"), 11, "الفشن", "El Fashn" },
                    { new Guid("0da11fbf-5b42-2f80-5638-8ffbca8affe7"), 18, "فوكة", "Fuka" },
                    { new Guid("0ebac249-62ff-c9c4-1b74-a2a17a97dc15"), 20, "أشمون", "Ashmoun" },
                    { new Guid("0eef7e89-5861-53c8-e519-5fd3254da821"), 22, "رفح", "Rafah" },
                    { new Guid("0ffbe018-9715-9c11-dbfd-3f3841932962"), 24, "الغردقة", "Hurghada" },
                    { new Guid("10474516-01bc-4304-fe75-0142dc5a2197"), 16, "نفيشة", "Nefisha" },
                    { new Guid("106591de-8067-67fd-9306-68fffc05d1ad"), 1, "الزمالك", "Zamalek" },
                    { new Guid("113a6ba2-1d1e-21e3-3213-efd1dadc6d09"), 26, "طهطا", "Tahta" },
                    { new Guid("1266bc68-cb45-40b3-e663-f90dc3523b44"), 13, "كفر البطيخ", "Kafr El Batikh" },
                    { new Guid("14df2597-9c60-e8b2-68b2-69dc041a5f08"), 4, "بنها", "Banha" },
                    { new Guid("1c41ff1d-4d41-74c3-c8c2-bfe9e71804fe"), 12, "السنبلاوين", "El Sinbillawein" },
                    { new Guid("1ca689c6-9c82-5955-2bfb-1c4f63817a33"), 1, "المطرية", "El Matareya" },
                    { new Guid("1d34f3c5-1753-9f79-5b97-707ba929c792"), 5, "الجنوب", "El Ganoub" },
                    { new Guid("1d58339f-7696-149c-4b68-4f79a5ad26d3"), 18, "سيدي عبد الرحمن", "Sidi Abdel Rahman" },
                    { new Guid("1e1aea7a-1f55-dd69-8ed4-9844969538a8"), 20, "تلا", "Tala" },
                    { new Guid("1f1b7543-752e-4c7d-96f0-6e9d9d3e7d21"), 21, "الداخلة", "Dakhla" },
                    { new Guid("20ae79f4-0f18-0c00-390c-989938599791"), 15, "قطور", "Kotour" },
                    { new Guid("21094bb9-ebf0-0429-4189-8f4310c2ffb9"), 24, "سفاجا", "Safaga" },
                    { new Guid("22be40ff-4434-2121-db61-2b0db0d7ed18"), 13, "عزبة البرج", "Ezbet El Borg" },
                    { new Guid("238d9e2a-de80-7ee7-b4ee-57a7da601e8e"), 20, "باجور", "Bagour" },
                    { new Guid("2422da45-c189-bcbb-87e0-9e7548671c68"), 15, "المحلة الكبرى", "El Mahalla El Kubra" },
                    { new Guid("25f3fe82-468a-d90f-cc63-ffe2f06c6dfa"), 22, "الشيخ زويد", "Sheikh Zuweid" },
                    { new Guid("2652fb2d-5964-078e-9e10-e6b4d063b4b4"), 12, "شربين", "Sherbin" },
                    { new Guid("27c8fec1-0079-b6fa-2067-e639c5baf225"), 24, "حلايب", "Halayeb" },
                    { new Guid("2832c8c5-e71b-c904-406c-98b976032aba"), 7, "البياضية", "El Bayadiya" },
                    { new Guid("2b40910b-0a0d-0ae8-05e7-d91d13bb6022"), 24, "مرسى علم", "Marsa Alam" },
                    { new Guid("2c873b58-c171-d7ce-ce9a-e84119458284"), 14, "منشية صبري", "Manshiet Sabri" },
                    { new Guid("2cd6b5c0-1fc2-6dd7-dfe6-167483fc48ec"), 4, "كفر شكر", "Kafr Shukr" },
                    { new Guid("2cdf3556-039e-498e-a711-c59d6e26ea6b"), 2, "سيدي جابر", "Sidi Gaber" },
                    { new Guid("2ce74997-572e-7201-3bb9-07a3b222f612"), 19, "العدوة", "El Adwa" },
                    { new Guid("2da7ebdc-648f-61d8-f9db-4fc87f2d0f44"), 11, "ناصر", "Naser" },
                    { new Guid("2e00b227-456f-fccc-1c15-f6148c56f77d"), 16, "أبو صوير", "Abu Suwair" },
                    { new Guid("2e9b81b5-0c17-861c-109a-31a7be76c1dd"), 27, "الطور", "El Tor" },
                    { new Guid("3067e220-7981-1434-0533-7cb12c63ef10"), 21, "باريس", "Baris" },
                    { new Guid("33b5b59a-7800-7f0a-a7b1-197e27b6fbd4"), 16, "السلام", "El Salam" },
                    { new Guid("350a56f6-496e-cb6c-9697-48c5e02001cd"), 20, "مدينة السادات", "Sadat City" },
                    { new Guid("358d9b83-745c-c968-2f7e-149acdf0ee37"), 10, "الرحمانية", "Rahmaniya" },
                    { new Guid("36212528-f5de-bb7a-25b3-6a4cb3ea533d"), 8, "نصر النوبة", "Nasr Al Nuba" },
                    { new Guid("363775d4-3f7d-132b-1f66-b94dd5ae4713"), 3, "إمبابة", "Imbaba" },
                    { new Guid("36632cec-c08c-3257-3d02-8a2e9bb08398"), 14, "سنهور", "Sanhur" },
                    { new Guid("38cf1794-3d41-ae39-f2e0-467cff044789"), 2, "سموحة", "Smouha" },
                    { new Guid("3a7c363b-12ae-63ca-5161-a4fdc3e3d7f7"), 8, "كوم أمبو", "Kom Ombo" },
                    { new Guid("3b50fff5-9071-6f7e-f894-b2bea738bed7"), 8, "الرديسية", "Radisiya" },
                    { new Guid("3d0f319a-5647-1221-4ff2-0c8cae493c0b"), 11, "بني سويف الجديدة", "New Beni Suef" },
                    { new Guid("3db9759e-90c4-57ed-7f2f-754131dc75e2"), 15, "السنطة", "El Santa" },
                    { new Guid("41aa29e7-7a83-a65d-03dc-0b9fb0978216"), 1, "مصر الجديدة", "Heliopolis" },
                    { new Guid("42670f87-75eb-e81a-16e8-995b32f99d0c"), 13, "الروضة", "El Rouda" },
                    { new Guid("42823ff6-4775-43ab-f6fe-1884a90c8bd3"), 4, "مدينة العبور", "Obour City" },
                    { new Guid("44ee5f1a-779a-8aef-ebbe-ef04a1739871"), 10, "إيتاي البارود", "Itay El Barud" },
                    { new Guid("460fec95-e53f-c0fd-ad91-800c87201418"), 19, "مغاغة", "Maghagha" },
                    { new Guid("4811a409-ff86-95c7-c0e4-54a0775338e1"), 6, "الأربعين", "Arbaeen" },
                    { new Guid("4b0ef03d-fdbd-facc-c50d-be20988ae63c"), 2, "ميامي", "Miami" },
                    { new Guid("4b85a1cf-399d-d50e-0e5f-b3a99f45b2d2"), 2, "برج العرب", "Borg El Arab" },
                    { new Guid("4bbd132a-b0c0-34e5-7f45-5d777aff0bae"), 14, "إبشواي", "Ibsheway" },
                    { new Guid("4cf377ce-0e5d-5f63-045a-677bda3be86c"), 16, "القنطرة", "El Qantara" },
                    { new Guid("4d8f4c98-953a-14e1-b352-be55141b0978"), 12, "طلخا", "Talkha" },
                    { new Guid("51388e6a-d29c-dd67-bff3-7c4e3ed421d9"), 10, "رشيد", "Rashid" },
                    { new Guid("51629865-9d6e-4b9a-979d-6c01778e10eb"), 23, "قفط", "Qift" },
                    { new Guid("51cc33fe-0b1a-3957-466a-e26021bfe21e"), 8, "السباعية", "El Sibaiya" },
                    { new Guid("52e9608d-8c7d-07dc-b815-a85ef4109e6b"), 22, "نخل", "Nekhel" },
                    { new Guid("5457b795-eef0-6b0d-bb93-4e05c0d534c2"), 9, "الفتح", "El Fath" },
                    { new Guid("55a09aa1-f4dd-0dd7-b2e2-d7792cd0af0b"), 21, "موط", "Mut" },
                    { new Guid("57033d78-ae66-0758-d2ec-e8f89ea5832a"), 17, "فوه", "Fouh" },
                    { new Guid("5722e9cb-23a2-4eb1-4aea-6f0b0a795800"), 18, "الحمام", "El Hamam" },
                    { new Guid("57fc74a2-78e9-2736-d671-390a47b54125"), 7, "إسنا", "Esna" },
                    { new Guid("58ca6988-920a-0297-497c-c9a7f634f11a"), 21, "موط", "Mout" },
                    { new Guid("58ff65d4-7e79-8ec9-0984-889620ac6bf4"), 16, "القصاصين", "El Kasasin" },
                    { new Guid("5a89aafd-c05f-b4c5-fd39-852cd0ed9261"), 17, "الرياض", "Riyadh" },
                    { new Guid("5b209fd2-716f-6b9b-0e45-7ac894efa194"), 22, "نخل", "Nakhl" },
                    { new Guid("5d4a3a46-df6a-6d16-e961-f327121cc495"), 19, "دير مواس", "Deir Mawas" },
                    { new Guid("5d98c6ca-7757-536e-7d4c-2efba66e6424"), 17, "سيدي سالم", "Sidi Salem" },
                    { new Guid("5df9c41e-ace5-d6e3-bea5-8eaef9948ba4"), 5, "المناصرة", "El Manasra" },
                    { new Guid("5e2a6ead-5f0d-6606-022b-d0619c3b6c54"), 9, "ديروط", "Dairut" },
                    { new Guid("5faf587c-d29b-d860-7715-4341f98e54e6"), 15, "كفر الزيات", "Kafr El Zayat" },
                    { new Guid("6241f69d-b91e-9dff-c246-ab38c6c98951"), 2, "المنتزه", "Montazah" },
                    { new Guid("6340a17b-93ab-260e-f4d7-8224a544188a"), 24, "رأس غارب", "Ras Gharib" },
                    { new Guid("65c96fce-ea4d-3ea7-b22b-c1d0629c93bf"), 16, "التل الكبير", "El Tal El Kabir" },
                    { new Guid("6609181f-97df-a4b6-b2e7-9e66dbe79f48"), 11, "ببا", "Beba" },
                    { new Guid("667ec371-5287-c12e-206f-054692fe9a7c"), 19, "سمالوط", "Samalut" },
                    { new Guid("67c7990a-f566-7173-019b-ca8786b6cae7"), 10, "شبراخيت", "Shubrakhit" },
                    { new Guid("6b6765ff-8044-904a-9e00-ff9e8421b344"), 19, "مطاي", "Matay" },
                    { new Guid("6cc058ca-81d6-608d-7e5a-449a9baaa6d0"), 20, "الشهداء", "Shohadaa" },
                    { new Guid("6df2042b-6849-9037-57db-88b38cecbb1a"), 23, "نقادة", "Naqada" },
                    { new Guid("6e980bc0-5b0b-0be6-0803-a70440628197"), 3, "السادس من أكتوبر", "6th of October" },
                    { new Guid("6f2d921f-9bb8-cca3-eb45-3d3aff82878a"), 14, "الفيوم الجديدة", "New Fayoum" },
                    { new Guid("713fa8da-6ec2-6d22-2433-0c5e96450b74"), 19, "مدينة المنيا", "Minya City" },
                    { new Guid("71c53919-82ef-5b2a-d050-90979d093f49"), 20, "سرس الليان", "Sers El Lyan" },
                    { new Guid("74df2e38-b70e-31b8-333e-de2968446838"), 7, "القرنة", "El Qurna" },
                    { new Guid("759c3d71-20e4-36db-7b01-c8eb6dbe6525"), 4, "قها", "Qaha" },
                    { new Guid("76735c08-513d-40dd-a2ce-2d1fdcc260a5"), 27, "رأس سدر", "Ras Sidr" },
                    { new Guid("776bdbb8-49ac-b5dd-f5ce-088002826a9a"), 23, "أرمنت", "Armant" },
                    { new Guid("78f976a3-317e-aa42-2047-d082819cf349"), 13, "ميت أبو غالب", "Mit Abou Ghaleb" },
                    { new Guid("7a8ab042-f659-476b-df70-9bf2dc7072f3"), 10, "حوش عيسى", "Hosh Issa" },
                    { new Guid("7abd8d23-ba61-72fe-b5c4-0cdea0249d1e"), 12, "أجا", "Aga" },
                    { new Guid("7aebca76-fc66-f326-7868-51ba98117916"), 14, "يوسف الصديق", "Youssef El Seddik" },
                    { new Guid("7b1ea487-3aec-d22d-2903-66c1e0d92ee9"), 8, "دراو", "Daraw" },
                    { new Guid("7be6c572-c514-5898-2b57-e4e18fd36c1f"), 20, "شبين الكوم", "Shebin El Kom" },
                    { new Guid("7df3b5e0-51ee-740f-cf07-c7b95b2a28ce"), 26, "البلينا", "El Balyana" },
                    { new Guid("7e1a508c-fe30-6cc2-38e4-a97db10b6788"), 6, "بورتوفيق", "Port Tawfik" },
                    { new Guid("7f16ad5c-f506-b035-8e82-836f4e97e1e4"), 24, "شلاتين", "Shalatin" },
                    { new Guid("7ff8c041-86dc-fb71-1423-6ca1bf4b96b8"), 18, "الضبعة", "El Dabaa" },
                    { new Guid("80ace5fe-fb64-6122-8d5e-31b0077939ab"), 11, "سمسطا", "Sumusta" },
                    { new Guid("816a2332-5eec-a671-c13c-46a8a2264c93"), 20, "قويسنا", "Quesna" },
                    { new Guid("817d6d15-cd7e-4077-dbc1-2639f8dc8d26"), 6, "فيصل", "Faisal" },
                    { new Guid("8194cc09-87b3-b738-bd44-b636610ac856"), 23, "قوص", "Qus" },
                    { new Guid("81ef7991-9b08-26c6-511d-22680a8ee0bb"), 7, "الكرنك", "Karnak" },
                    { new Guid("834ad46c-c120-8f53-6015-4c626ffc0d56"), 23, "مدينة قنا", "Qena City" },
                    { new Guid("84d092fd-500b-34b8-2928-b221632a3b51"), 24, "القصير", "El Quseir" },
                    { new Guid("85099588-3d4b-3a0d-a0ae-f05dd8ee391c"), 17, "الحامول", "Hamoul" },
                    { new Guid("8510120b-e31b-ce0c-9319-181633f4002d"), 21, "بلاط", "Balat" },
                    { new Guid("8592bc51-061d-e124-bc75-bec01c7bce91"), 17, "قلين", "Qallin" },
                    { new Guid("87a74647-fe5b-e046-0efc-4bfee40d06dc"), 1, "وسط البلد", "Downtown" },
                    { new Guid("88442d49-78aa-f413-43f0-3d11b32c340e"), 3, "المهندسين", "Mohandessin" },
                    { new Guid("8a5394b5-20ec-dab5-f16d-ec16dff3e78a"), 20, "منوف", "Menouf" },
                    { new Guid("8a6f69fb-3ae7-3b43-f381-8d1245dcac1f"), 18, "مرسى مطروح", "Marsa Matrouh" },
                    { new Guid("8a81e3b3-eb1d-8e0b-0a7f-c498b0e5590c"), 1, "مدينة نصر", "Nasr City" },
                    { new Guid("8b7a7adf-9fc6-f99d-6915-9d5d95f42fc4"), 4, "طوخ", "Tukh" },
                    { new Guid("8c886fca-c8c1-c42d-0e85-11616a6eb4ec"), 26, "جرجا", "Gerga" },
                    { new Guid("8cb17f18-941c-308d-9cc3-15596d6e5fc9"), 27, "أبو رديس", "Abu Rudeis" },
                    { new Guid("8f76085b-575e-db8e-0dd7-e5f1c04bc008"), 5, "الزهور", "El Zohour" },
                    { new Guid("8f78f961-91b2-f24c-d94f-233c69e3edaa"), 14, "أبشواي", "Abshaway" },
                    { new Guid("8fe8f25e-2459-1761-a8d5-8cc7e266aa7a"), 6, "الأمل", "El Amal" },
                    { new Guid("90068c85-131a-8ad1-e050-6bfc7fb7471e"), 26, "طما", "Tima" },
                    { new Guid("90e096d7-a552-372e-c60a-11cea3d9fe26"), 16, "فايد", "Fayed" },
                    { new Guid("92507fad-d108-2150-8c33-9f504c7e69b4"), 11, "مدينة بني سويف", "Beni Suef City" },
                    { new Guid("92b3e3dc-17c3-3f4e-c46f-3379fb4ef791"), 12, "المنصورة", "Mansoura" },
                    { new Guid("94145319-d3b3-7e06-0ec0-920617011b97"), 22, "الحسنة", "El Hasana" },
                    { new Guid("956785f4-11d5-ecb6-5019-a6a5f9942bb3"), 1, "المعادي", "Maadi" },
                    { new Guid("95ebf78f-8340-f0d7-c12c-018e2c824f08"), 3, "كرداسة", "Kerdasa" },
                    { new Guid("9622aaf9-5b5e-f2b4-394b-6e6e67837ebf"), 22, "بئر العبد", "Bir al-Abed" },
                    { new Guid("971b7f8d-e504-3733-8357-e1ae3b16a4d3"), 27, "دهب", "Dahab" },
                    { new Guid("97ea8a71-1f73-8c96-3889-79c3e9090717"), 27, "شرم الشيخ", "Sharm El Sheikh" },
                    { new Guid("97ef7994-ede2-d687-287d-9b25021094d3"), 5, "الغرب", "El Gharb" },
                    { new Guid("9916d3c4-2e50-50fb-6c9a-ae0283551fcd"), 7, "الزينية", "El Zeiniya" },
                    { new Guid("99f74331-6edf-89d4-b3cb-c2ff6adac494"), 1, "عين شمس", "Ain Shams" },
                    { new Guid("9a8192bd-fd11-4c65-d0d5-8707c56ac1fc"), 15, "زفتى", "Zefta" },
                    { new Guid("9ae30b42-6c1c-d58b-8463-5e6245ed3e52"), 3, "الدقي", "Dokki" },
                    { new Guid("9b99f213-83df-d13f-b669-1a25f221abc1"), 23, "دشنا", "Dishna" },
                    { new Guid("9d5edc6b-01df-2788-d3c5-72ffa114336c"), 3, "فيصل", "Faisal" },
                    { new Guid("9d759b18-ca03-4c05-b35f-4f52e7cfb1c5"), 9, "القوصية", "El Qusiya" },
                    { new Guid("9f09fe33-2509-385c-1e48-6d8cde42d541"), 3, "بولاق الدكرور", "Bulaq El Dakrour" },
                    { new Guid("a1c2f9d8-a4da-cbac-e906-dc374ed3acac"), 4, "قليوب", "Qalyub" },
                    { new Guid("a2ebb074-dbc4-8d4d-e8f2-08a9cfc44989"), 15, "سمنود", "Samannoud" },
                    { new Guid("a5d96dd1-7d22-8631-22f5-ad4ce5a58975"), 22, "بئر العبد", "Bir El Abd" },
                    { new Guid("a5f21fc9-375d-c5db-e5ad-e3e204badb64"), 26, "المراغة", "El Maragha" },
                    { new Guid("a7d8670f-cac2-bec9-bb8d-e4ad2be52790"), 3, "العجوزة", "Agouza" },
                    { new Guid("a8343660-8743-526a-1b27-cf9f946e9056"), 17, "دسوق", "Desouk" },
                    { new Guid("a9122f78-9e02-3012-99da-c1509836cca9"), 11, "الواسطى", "El Wasta" },
                    { new Guid("a9859f14-6353-fd2e-24d1-f1bc3cb6afb0"), 17, "مطوبس", "Metoubes" },
                    { new Guid("ab5e3295-ebd0-0e0e-e639-37b185c5ce9f"), 14, "إطسا", "Etsa" },
                    { new Guid("ac2f8e4f-c263-d578-cc79-9ff1d3c46f89"), 5, "المناخ", "El Manakh" },
                    { new Guid("ad96c16d-7245-c0fb-20b6-1cb45da61318"), 27, "طابا", "Taba" },
                    { new Guid("adab4432-9d6b-b3f0-f7e3-1143613153d8"), 13, "مدينة دمياط", "Damietta City" },
                    { new Guid("b0d11d44-d8e4-4caa-25f6-c8d809395556"), 19, "المنيا الجديدة", "New Minya" },
                    { new Guid("b10cbe12-646e-7c6c-4e4e-60b34c61c2da"), 10, "المحمودية", "Mahmoudiyah" },
                    { new Guid("b1ac8dd7-a9b7-b5e8-ba4d-710c4250aac6"), 10, "أبو حمص", "Abu Hummus" },
                    { new Guid("b1b4bf90-94e8-b137-7ae3-6ee63a4a3160"), 6, "عتاقة", "Attaka" },
                    { new Guid("b2a18234-22dc-4175-a5d0-d8c224b7b203"), 13, "كفر سعد", "Kafr Saad" },
                    { new Guid("b2ee4373-ec61-ce4d-0c3c-65fbb75a71e9"), 17, "مدينة كفر الشيخ", "Kafr El Sheikh City" },
                    { new Guid("b4ec2eec-588d-69b7-63c6-cb5b22fa62ad"), 9, "منفلوط", "Manfalut" },
                    { new Guid("b501db7f-e2b4-8ff6-f86e-9080c565b702"), 6, "السلام", "El Salam" },
                    { new Guid("b72a329d-8c12-038c-de47-f2a172f9d990"), 18, "سيوة", "Siwa" },
                    { new Guid("bacc09f5-615a-978d-bd42-ddf479633faa"), 2, "بحري", "Bahary" },
                    { new Guid("bd5ee1d0-93f3-c429-3222-a6be862bf9de"), 6, "السويس", "El Suez" },
                    { new Guid("bd8c99b8-0aba-77dd-5573-04ef26e395dd"), 22, "المساعيد", "El Massaeed" },
                    { new Guid("bdd8cab5-7157-8f2a-4477-8370fb100fa0"), 9, "البداري", "El Badari" },
                    { new Guid("beb0b551-2a7b-53a4-d6e6-b8fbb747dc22"), 24, "الجونة", "El Gouna" },
                    { new Guid("bed8bc59-c445-b9da-694f-23f7bf712a49"), 11, "الفشن", "El Fashn" },
                    { new Guid("bef4a3a2-3a5c-e939-2fc8-61d6669e94d1"), 27, "خليج نعمة", "Naama Bay" },
                    { new Guid("bf3642e8-046c-418d-dba3-d27e0b0006d2"), 13, "فارسكور", "Faraskour" },
                    { new Guid("bf8797ec-02ad-f7a5-ba31-60656df32f15"), 8, "مدينة أسوان", "Aswan City" },
                    { new Guid("c0ef55c2-b87a-fe69-6943-56b017e9ce4b"), 21, "القصر", "El Qasr" },
                    { new Guid("c52c8539-7082-be26-fc23-2985c7a4aada"), 21, "الخارجة", "Kharga" },
                    { new Guid("c699d6ed-e8c2-f531-3fc5-90dba753616c"), 9, "أبنوب", "Abnoub" },
                    { new Guid("c69dadac-5d7e-d798-3401-3e745bc6a6a4"), 4, "شبين القناطر", "Shibin El Qanater" },
                    { new Guid("c79d0203-3d35-56e7-e1a4-7268ecf16963"), 26, "أخميم", "Akhmim" },
                    { new Guid("c8ceabf1-2f9d-b340-08fa-afdefd5dd255"), 18, "السلوم", "Salloum" },
                    { new Guid("c9143355-05a8-ddc6-2ccc-eceecda0af97"), 21, "الفرافرة", "Farafra" },
                    { new Guid("cabcaf3a-0efe-d368-adf4-2fb2cfb55c8f"), 21, "باريس", "Paris" },
                    { new Guid("cc43db67-8f16-a955-0c39-480c92d4f6f9"), 27, "سانت كاترين", "Saint Catherine" },
                    { new Guid("cce4221f-d30c-6a40-d055-677414409b69"), 4, "شبرا الخيمة", "Shubra El Kheima" },
                    { new Guid("cd09aea5-1b6d-136b-5d14-b5d65af81c30"), 3, "الشيخ زايد", "Sheikh Zayed" },
                    { new Guid("cd4845f5-f1aa-4290-eaec-96164e2e0cdb"), 13, "الزرقا", "El Zarqa" },
                    { new Guid("cd845611-c0a5-9302-2e4a-bfceb78b1699"), 9, "ساحل سليم", "Sahel Selim" },
                    { new Guid("cf27f72b-819b-6f87-a366-94603c0d1120"), 10, "كفر الدوار", "Kafr El Dawwar" },
                    { new Guid("cf4997b9-57ce-e40d-cf6a-41da063e7773"), 13, "رأس البر", "Ras El Bar" },
                    { new Guid("cff720f7-6631-5fba-2941-6438dc494cf2"), 2, "الدخيلة", "El Dekhela" },
                    { new Guid("d053f0a4-e161-7367-469e-6347f43d370c"), 27, "نويبع", "Nuweiba" },
                    { new Guid("d12b3c87-d61a-1269-8928-922e676f5afe"), 5, "العرب", "El Arab" },
                    { new Guid("d25c832e-3315-66f5-9f14-65bf20eab7e0"), 1, "المرج", "El Marg" },
                    { new Guid("d587ec2d-57a7-200c-1c1c-19618dc8e932"), 7, "طيبة الجديدة", "New Tiba" },
                    { new Guid("d7da2bdb-9639-5936-9034-fb5f31fd8037"), 16, "القنطرة شرق", "El Qantara East" },
                    { new Guid("d7eab6e5-d8ce-11c8-eecc-0da5df013cce"), 15, "طنطا", "Tanta" },
                    { new Guid("d7ffaf10-353b-57c1-8bd3-1030a786a678"), 2, "العامرية", "Amreya" },
                    { new Guid("d859b6d9-7ad7-4a50-20f3-1158feb8c936"), 7, "الطود", "El Tod" },
                    { new Guid("d8f76121-646e-4bb3-f7d8-d4b3799441e6"), 18, "العلمين", "El Alamein" },
                    { new Guid("d9936df0-6717-0c7a-0e38-2c949bea660e"), 7, "أرمنت", "Armant" },
                    { new Guid("d9cb9b96-8fe0-a1d2-a3ad-13cfffecf0de"), 1, "شبرا", "Shubra" },
                    { new Guid("dcdcb7aa-80a0-9f9c-4215-b21ee2934afd"), 27, "أبو زنيمة", "Abu Zenima" },
                    { new Guid("de37a22f-fb51-a162-c97c-e6ca88ab9dfe"), 6, "الجناين", "Ganayen" },
                    { new Guid("de9c3c91-21b2-2215-583f-3661f709f3ca"), 19, "أبو قرقاص", "Abu Qurqas" },
                    { new Guid("df13e558-c597-426b-0a32-6347c7262598"), 22, "القنطرة شرق", "El Qantara East" },
                    { new Guid("e23f26cd-6c9e-371b-dc25-f2f87603dd1a"), 17, "بيلا", "Biala" },
                    { new Guid("e2c27bd9-d525-6294-2c12-e1a5af0dc756"), 8, "كلابشة", "Kalabsha" },
                    { new Guid("e2e9be9e-f0f8-35bb-eb3d-2ff56cd6ddf7"), 19, "ملوي", "Mallawi" },
                    { new Guid("e40b50f1-8e89-ba2c-1211-9965db0d9cc9"), 5, "الضواحي", "El Dawahy" },
                    { new Guid("e40e4153-e866-1802-e421-53564fe11265"), 8, "البصيلية", "El Basaliya" },
                    { new Guid("e52cfb47-fe38-842a-c961-e5866cf253d1"), 12, "دكرنس", "Dikirnis" },
                    { new Guid("e5921402-d39b-afe6-30f3-96a03902c714"), 11, "إهناسيا", "Ihnasia" },
                    { new Guid("e6b9f4ae-8fb1-1f84-5b49-c226b6581168"), 7, "الطود", "El Tud" },
                    { new Guid("e8de82ac-ec0c-0ec1-6aed-7a7b9df8acf0"), 15, "مدينة نصر", "Nasr City" },
                    { new Guid("e9775523-13bc-f305-8589-c206f8069cd5"), 9, "أبنوب", "Abnub" },
                    { new Guid("ea27d6ec-9a8d-552d-5b63-ca587e815570"), 12, "ميت غمر", "Mit Ghamr" },
                    { new Guid("eb0d267a-112e-17fe-9b07-8f8e95bfd08d"), 15, "بسيون", "Bassioun" },
                    { new Guid("ee3750f5-873d-b35a-3f03-1ba768874079"), 26, "جهينة", "Juhayna" },
                    { new Guid("ee3c3199-5636-bea7-5f1d-f7c7eaf2bc52"), 6, "الجناين", "El Ganayen" },
                    { new Guid("eed83bde-0125-9ece-7cb2-65c5b91b1b2a"), 15, "طلا", "Tala" },
                    { new Guid("efda9b5c-1c33-b6c1-94c3-01d6736b161d"), 14, "سنورس", "Sinnuris" },
                    { new Guid("f00117e8-7a49-177a-2faa-dc2c92fe097e"), 2, "العجمي", "Agami" },
                    { new Guid("f13d29ec-ac8d-44de-5831-7b46b624f18b"), 26, "دار السلام", "Dar El Salam" },
                    { new Guid("f13f94a3-a8d9-f20a-e1e3-a97dd497a797"), 12, "المنزلة", "El Manzala" },
                    { new Guid("f1a8b754-6cfc-b16a-9f5c-b0935e17b8c3"), 13, "دمياط الجديدة", "New Damietta" },
                    { new Guid("f291dc44-5f6c-1b1b-3043-27c9abef515c"), 20, "بركة السبع", "Berket El Sab" },
                    { new Guid("f295d34b-7a06-3467-8687-6f03113c5c53"), 5, "الشرق", "El Sharq" },
                    { new Guid("f32d46c3-87d7-20dc-561d-ce2aae7b888f"), 8, "أبو سمبل", "Abu Simbel" },
                    { new Guid("f4295660-1900-2254-bd08-5f6b96b83c20"), 10, "إدكو", "Edko" },
                    { new Guid("f57106ec-c595-2946-b99b-f4a2bd2caaa9"), 7, "مدينة الأقصر", "Luxor City" },
                    { new Guid("f5a3734a-ccd6-f0a7-13c5-f7bdc9a081a3"), 23, "نجع حمادي", "Nag Hammadi" },
                    { new Guid("f5b880e3-402a-1fa7-79ec-3fdd96897d5a"), 24, "خليج مكادي", "Makadi Bay" },
                    { new Guid("f5c5caf0-3d14-5687-5490-10f9e08c90ca"), 14, "طامية", "Tamiya" },
                    { new Guid("f5ef0b93-d908-7b18-ad65-880dd51c6bd0"), 23, "أبو تشت", "Abu Tesht" },
                    { new Guid("f6c5b1ce-4ed4-2efd-940f-e6b1b1d28006"), 23, "الوقف", "Waqf" },
                    { new Guid("f8ddb734-6806-7ce7-416f-5195a2ee5388"), 21, "بشندي", "Bashendi" },
                    { new Guid("f9077054-18ba-e918-692d-67b1fb1a6ca2"), 23, "فرشوط", "Farshout" },
                    { new Guid("f945e658-5880-4bd8-ead9-e8ded65dc1f7"), 18, "النجيلة", "El Negila" },
                    { new Guid("f991f366-2be3-7710-454f-a1c55709dc82"), 9, "مدينة أسيوط", "Assiut City" },
                    { new Guid("fa0bb3d5-d45f-626f-d7fd-ea2710c3d6b7"), 10, "دمنهور", "Damanhour" },
                    { new Guid("fa274f68-a7a0-ffac-fa25-698752e96505"), 17, "بلطيم", "Baltim" },
                    { new Guid("fa40a969-49ba-3c57-4c18-ca9d8f23a55b"), 26, "مدينة سوهاج", "Sohag City" },
                    { new Guid("fa5eec73-7184-a067-6afc-a2c9c50f0257"), 8, "إدفو", "Edfu" },
                    { new Guid("fa9f81d2-f37d-2cad-c1f2-c11a429f4c42"), 12, "بلقاس", "Bilqas" },
                    { new Guid("fb01d005-0df2-f96b-6b16-888c2faba024"), 2, "الجمرك", "El Gomrok" },
                    { new Guid("fc60c61e-aa51-ed9a-6b27-96e0b97944a6"), 1, "مدينة 15 مايو", "15th of May City" },
                    { new Guid("fd95c0d0-94d7-9d1a-218c-51028bc16aed"), 11, "أهناسيا", "Ahnasia" },
                    { new Guid("fe3fb2ca-8e78-6619-9133-97657210b408"), 16, "مدينة الإسماعيلية", "Ismailia City" },
                    { new Guid("fee5e2aa-9ad4-e281-a319-4f387d2af565"), 4, "الخانكة", "El Khanka" },
                    { new Guid("fef1472e-e9b6-3672-c7e8-aa9f88108aac"), 18, "سيدي براني", "Sidi Barrani" },
                    { new Guid("ff6224cb-f1f8-0f42-d7f3-a563359a4120"), 3, "الهرم", "Haram" },
                    { new Guid("ffd6811f-e33a-288c-4638-de6b5fc764e4"), 14, "مدينة الفيوم", "Fayoum City" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("00e1b730-138c-68aa-527a-300b835bf7a5"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0185f125-9ad7-4e75-76cc-719e8b14c1b2"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0197bb9d-6292-9527-a3d3-50792f58fe53"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("01a24b39-8139-8ccc-af7d-a81457c9020f"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("02b18049-769f-a8af-199f-ba23e04fdf43"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("02b68222-9951-8111-4bb8-28459ff986e4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0752bb4d-4b27-a26e-7a9b-6cc587a29634"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("09f29961-2064-f049-df83-e1144b0c35b0"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0a63e97b-4d62-bcb4-3fe0-fc8baacaec38"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0b4cc371-3906-bf69-d62c-9646f3440cb3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0ba9618a-3b26-6e12-f2a2-3463101fe980"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0bd817cf-4521-8f2a-0e2f-9d04a4c375bd"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0da11fbf-5b42-2f80-5638-8ffbca8affe7"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0ebac249-62ff-c9c4-1b74-a2a17a97dc15"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0eef7e89-5861-53c8-e519-5fd3254da821"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("0ffbe018-9715-9c11-dbfd-3f3841932962"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("10474516-01bc-4304-fe75-0142dc5a2197"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("106591de-8067-67fd-9306-68fffc05d1ad"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("113a6ba2-1d1e-21e3-3213-efd1dadc6d09"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("1266bc68-cb45-40b3-e663-f90dc3523b44"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("14df2597-9c60-e8b2-68b2-69dc041a5f08"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("1c41ff1d-4d41-74c3-c8c2-bfe9e71804fe"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("1ca689c6-9c82-5955-2bfb-1c4f63817a33"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("1d34f3c5-1753-9f79-5b97-707ba929c792"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("1d58339f-7696-149c-4b68-4f79a5ad26d3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("1e1aea7a-1f55-dd69-8ed4-9844969538a8"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("1f1b7543-752e-4c7d-96f0-6e9d9d3e7d21"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("20ae79f4-0f18-0c00-390c-989938599791"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("21094bb9-ebf0-0429-4189-8f4310c2ffb9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("22be40ff-4434-2121-db61-2b0db0d7ed18"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("238d9e2a-de80-7ee7-b4ee-57a7da601e8e"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2422da45-c189-bcbb-87e0-9e7548671c68"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("25f3fe82-468a-d90f-cc63-ffe2f06c6dfa"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2652fb2d-5964-078e-9e10-e6b4d063b4b4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("27c8fec1-0079-b6fa-2067-e639c5baf225"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2832c8c5-e71b-c904-406c-98b976032aba"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2b40910b-0a0d-0ae8-05e7-d91d13bb6022"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2c873b58-c171-d7ce-ce9a-e84119458284"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2cd6b5c0-1fc2-6dd7-dfe6-167483fc48ec"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2cdf3556-039e-498e-a711-c59d6e26ea6b"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2ce74997-572e-7201-3bb9-07a3b222f612"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2da7ebdc-648f-61d8-f9db-4fc87f2d0f44"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2e00b227-456f-fccc-1c15-f6148c56f77d"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("2e9b81b5-0c17-861c-109a-31a7be76c1dd"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("3067e220-7981-1434-0533-7cb12c63ef10"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("33b5b59a-7800-7f0a-a7b1-197e27b6fbd4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("350a56f6-496e-cb6c-9697-48c5e02001cd"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("358d9b83-745c-c968-2f7e-149acdf0ee37"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("36212528-f5de-bb7a-25b3-6a4cb3ea533d"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("363775d4-3f7d-132b-1f66-b94dd5ae4713"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("36632cec-c08c-3257-3d02-8a2e9bb08398"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("38cf1794-3d41-ae39-f2e0-467cff044789"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("3a7c363b-12ae-63ca-5161-a4fdc3e3d7f7"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("3b50fff5-9071-6f7e-f894-b2bea738bed7"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("3d0f319a-5647-1221-4ff2-0c8cae493c0b"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("3db9759e-90c4-57ed-7f2f-754131dc75e2"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("41aa29e7-7a83-a65d-03dc-0b9fb0978216"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("42670f87-75eb-e81a-16e8-995b32f99d0c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("42823ff6-4775-43ab-f6fe-1884a90c8bd3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("44ee5f1a-779a-8aef-ebbe-ef04a1739871"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("460fec95-e53f-c0fd-ad91-800c87201418"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("4811a409-ff86-95c7-c0e4-54a0775338e1"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("4b0ef03d-fdbd-facc-c50d-be20988ae63c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("4b85a1cf-399d-d50e-0e5f-b3a99f45b2d2"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("4bbd132a-b0c0-34e5-7f45-5d777aff0bae"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("4cf377ce-0e5d-5f63-045a-677bda3be86c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("4d8f4c98-953a-14e1-b352-be55141b0978"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("51388e6a-d29c-dd67-bff3-7c4e3ed421d9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("51629865-9d6e-4b9a-979d-6c01778e10eb"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("51cc33fe-0b1a-3957-466a-e26021bfe21e"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("52e9608d-8c7d-07dc-b815-a85ef4109e6b"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5457b795-eef0-6b0d-bb93-4e05c0d534c2"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("55a09aa1-f4dd-0dd7-b2e2-d7792cd0af0b"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("57033d78-ae66-0758-d2ec-e8f89ea5832a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5722e9cb-23a2-4eb1-4aea-6f0b0a795800"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("57fc74a2-78e9-2736-d671-390a47b54125"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("58ca6988-920a-0297-497c-c9a7f634f11a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("58ff65d4-7e79-8ec9-0984-889620ac6bf4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5a89aafd-c05f-b4c5-fd39-852cd0ed9261"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5b209fd2-716f-6b9b-0e45-7ac894efa194"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5d4a3a46-df6a-6d16-e961-f327121cc495"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5d98c6ca-7757-536e-7d4c-2efba66e6424"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5df9c41e-ace5-d6e3-bea5-8eaef9948ba4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5e2a6ead-5f0d-6606-022b-d0619c3b6c54"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("5faf587c-d29b-d860-7715-4341f98e54e6"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6241f69d-b91e-9dff-c246-ab38c6c98951"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6340a17b-93ab-260e-f4d7-8224a544188a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("65c96fce-ea4d-3ea7-b22b-c1d0629c93bf"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6609181f-97df-a4b6-b2e7-9e66dbe79f48"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("667ec371-5287-c12e-206f-054692fe9a7c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("67c7990a-f566-7173-019b-ca8786b6cae7"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6b6765ff-8044-904a-9e00-ff9e8421b344"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6cc058ca-81d6-608d-7e5a-449a9baaa6d0"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6df2042b-6849-9037-57db-88b38cecbb1a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6e980bc0-5b0b-0be6-0803-a70440628197"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("6f2d921f-9bb8-cca3-eb45-3d3aff82878a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("713fa8da-6ec2-6d22-2433-0c5e96450b74"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("71c53919-82ef-5b2a-d050-90979d093f49"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("74df2e38-b70e-31b8-333e-de2968446838"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("759c3d71-20e4-36db-7b01-c8eb6dbe6525"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("76735c08-513d-40dd-a2ce-2d1fdcc260a5"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("776bdbb8-49ac-b5dd-f5ce-088002826a9a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("78f976a3-317e-aa42-2047-d082819cf349"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7a8ab042-f659-476b-df70-9bf2dc7072f3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7abd8d23-ba61-72fe-b5c4-0cdea0249d1e"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7aebca76-fc66-f326-7868-51ba98117916"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7b1ea487-3aec-d22d-2903-66c1e0d92ee9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7be6c572-c514-5898-2b57-e4e18fd36c1f"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7df3b5e0-51ee-740f-cf07-c7b95b2a28ce"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7e1a508c-fe30-6cc2-38e4-a97db10b6788"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7f16ad5c-f506-b035-8e82-836f4e97e1e4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("7ff8c041-86dc-fb71-1423-6ca1bf4b96b8"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("80ace5fe-fb64-6122-8d5e-31b0077939ab"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("816a2332-5eec-a671-c13c-46a8a2264c93"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("817d6d15-cd7e-4077-dbc1-2639f8dc8d26"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8194cc09-87b3-b738-bd44-b636610ac856"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("81ef7991-9b08-26c6-511d-22680a8ee0bb"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("834ad46c-c120-8f53-6015-4c626ffc0d56"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("84d092fd-500b-34b8-2928-b221632a3b51"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("85099588-3d4b-3a0d-a0ae-f05dd8ee391c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8510120b-e31b-ce0c-9319-181633f4002d"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8592bc51-061d-e124-bc75-bec01c7bce91"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("87a74647-fe5b-e046-0efc-4bfee40d06dc"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("88442d49-78aa-f413-43f0-3d11b32c340e"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8a5394b5-20ec-dab5-f16d-ec16dff3e78a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8a6f69fb-3ae7-3b43-f381-8d1245dcac1f"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8a81e3b3-eb1d-8e0b-0a7f-c498b0e5590c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8b7a7adf-9fc6-f99d-6915-9d5d95f42fc4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8c886fca-c8c1-c42d-0e85-11616a6eb4ec"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8cb17f18-941c-308d-9cc3-15596d6e5fc9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8f76085b-575e-db8e-0dd7-e5f1c04bc008"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8f78f961-91b2-f24c-d94f-233c69e3edaa"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("8fe8f25e-2459-1761-a8d5-8cc7e266aa7a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("90068c85-131a-8ad1-e050-6bfc7fb7471e"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("90e096d7-a552-372e-c60a-11cea3d9fe26"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("92507fad-d108-2150-8c33-9f504c7e69b4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("92b3e3dc-17c3-3f4e-c46f-3379fb4ef791"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("94145319-d3b3-7e06-0ec0-920617011b97"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("956785f4-11d5-ecb6-5019-a6a5f9942bb3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("95ebf78f-8340-f0d7-c12c-018e2c824f08"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9622aaf9-5b5e-f2b4-394b-6e6e67837ebf"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("971b7f8d-e504-3733-8357-e1ae3b16a4d3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("97ea8a71-1f73-8c96-3889-79c3e9090717"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("97ef7994-ede2-d687-287d-9b25021094d3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9916d3c4-2e50-50fb-6c9a-ae0283551fcd"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("99f74331-6edf-89d4-b3cb-c2ff6adac494"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9a8192bd-fd11-4c65-d0d5-8707c56ac1fc"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9ae30b42-6c1c-d58b-8463-5e6245ed3e52"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9b99f213-83df-d13f-b669-1a25f221abc1"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9d5edc6b-01df-2788-d3c5-72ffa114336c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9d759b18-ca03-4c05-b35f-4f52e7cfb1c5"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("9f09fe33-2509-385c-1e48-6d8cde42d541"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a1c2f9d8-a4da-cbac-e906-dc374ed3acac"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a2ebb074-dbc4-8d4d-e8f2-08a9cfc44989"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a5d96dd1-7d22-8631-22f5-ad4ce5a58975"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a5f21fc9-375d-c5db-e5ad-e3e204badb64"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a7d8670f-cac2-bec9-bb8d-e4ad2be52790"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a8343660-8743-526a-1b27-cf9f946e9056"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a9122f78-9e02-3012-99da-c1509836cca9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("a9859f14-6353-fd2e-24d1-f1bc3cb6afb0"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ab5e3295-ebd0-0e0e-e639-37b185c5ce9f"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ac2f8e4f-c263-d578-cc79-9ff1d3c46f89"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ad96c16d-7245-c0fb-20b6-1cb45da61318"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("adab4432-9d6b-b3f0-f7e3-1143613153d8"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b0d11d44-d8e4-4caa-25f6-c8d809395556"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b10cbe12-646e-7c6c-4e4e-60b34c61c2da"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b1ac8dd7-a9b7-b5e8-ba4d-710c4250aac6"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b1b4bf90-94e8-b137-7ae3-6ee63a4a3160"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b2a18234-22dc-4175-a5d0-d8c224b7b203"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b2ee4373-ec61-ce4d-0c3c-65fbb75a71e9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b4ec2eec-588d-69b7-63c6-cb5b22fa62ad"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b501db7f-e2b4-8ff6-f86e-9080c565b702"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("b72a329d-8c12-038c-de47-f2a172f9d990"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bacc09f5-615a-978d-bd42-ddf479633faa"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bd5ee1d0-93f3-c429-3222-a6be862bf9de"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bd8c99b8-0aba-77dd-5573-04ef26e395dd"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bdd8cab5-7157-8f2a-4477-8370fb100fa0"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("beb0b551-2a7b-53a4-d6e6-b8fbb747dc22"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bed8bc59-c445-b9da-694f-23f7bf712a49"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bef4a3a2-3a5c-e939-2fc8-61d6669e94d1"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bf3642e8-046c-418d-dba3-d27e0b0006d2"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("bf8797ec-02ad-f7a5-ba31-60656df32f15"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("c0ef55c2-b87a-fe69-6943-56b017e9ce4b"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("c52c8539-7082-be26-fc23-2985c7a4aada"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("c699d6ed-e8c2-f531-3fc5-90dba753616c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("c69dadac-5d7e-d798-3401-3e745bc6a6a4"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("c79d0203-3d35-56e7-e1a4-7268ecf16963"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("c8ceabf1-2f9d-b340-08fa-afdefd5dd255"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("c9143355-05a8-ddc6-2ccc-eceecda0af97"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cabcaf3a-0efe-d368-adf4-2fb2cfb55c8f"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cc43db67-8f16-a955-0c39-480c92d4f6f9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cce4221f-d30c-6a40-d055-677414409b69"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cd09aea5-1b6d-136b-5d14-b5d65af81c30"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cd4845f5-f1aa-4290-eaec-96164e2e0cdb"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cd845611-c0a5-9302-2e4a-bfceb78b1699"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cf27f72b-819b-6f87-a366-94603c0d1120"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cf4997b9-57ce-e40d-cf6a-41da063e7773"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("cff720f7-6631-5fba-2941-6438dc494cf2"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d053f0a4-e161-7367-469e-6347f43d370c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d12b3c87-d61a-1269-8928-922e676f5afe"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d25c832e-3315-66f5-9f14-65bf20eab7e0"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d587ec2d-57a7-200c-1c1c-19618dc8e932"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d7da2bdb-9639-5936-9034-fb5f31fd8037"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d7eab6e5-d8ce-11c8-eecc-0da5df013cce"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d7ffaf10-353b-57c1-8bd3-1030a786a678"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d859b6d9-7ad7-4a50-20f3-1158feb8c936"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d8f76121-646e-4bb3-f7d8-d4b3799441e6"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d9936df0-6717-0c7a-0e38-2c949bea660e"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("d9cb9b96-8fe0-a1d2-a3ad-13cfffecf0de"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("dcdcb7aa-80a0-9f9c-4215-b21ee2934afd"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("de37a22f-fb51-a162-c97c-e6ca88ab9dfe"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("de9c3c91-21b2-2215-583f-3661f709f3ca"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("df13e558-c597-426b-0a32-6347c7262598"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e23f26cd-6c9e-371b-dc25-f2f87603dd1a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e2c27bd9-d525-6294-2c12-e1a5af0dc756"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e2e9be9e-f0f8-35bb-eb3d-2ff56cd6ddf7"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e40b50f1-8e89-ba2c-1211-9965db0d9cc9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e40e4153-e866-1802-e421-53564fe11265"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e52cfb47-fe38-842a-c961-e5866cf253d1"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e5921402-d39b-afe6-30f3-96a03902c714"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e6b9f4ae-8fb1-1f84-5b49-c226b6581168"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e8de82ac-ec0c-0ec1-6aed-7a7b9df8acf0"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("e9775523-13bc-f305-8589-c206f8069cd5"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ea27d6ec-9a8d-552d-5b63-ca587e815570"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("eb0d267a-112e-17fe-9b07-8f8e95bfd08d"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ee3750f5-873d-b35a-3f03-1ba768874079"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ee3c3199-5636-bea7-5f1d-f7c7eaf2bc52"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("eed83bde-0125-9ece-7cb2-65c5b91b1b2a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("efda9b5c-1c33-b6c1-94c3-01d6736b161d"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f00117e8-7a49-177a-2faa-dc2c92fe097e"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f13d29ec-ac8d-44de-5831-7b46b624f18b"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f13f94a3-a8d9-f20a-e1e3-a97dd497a797"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f1a8b754-6cfc-b16a-9f5c-b0935e17b8c3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f291dc44-5f6c-1b1b-3043-27c9abef515c"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f295d34b-7a06-3467-8687-6f03113c5c53"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f32d46c3-87d7-20dc-561d-ce2aae7b888f"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f4295660-1900-2254-bd08-5f6b96b83c20"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f57106ec-c595-2946-b99b-f4a2bd2caaa9"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f5a3734a-ccd6-f0a7-13c5-f7bdc9a081a3"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f5b880e3-402a-1fa7-79ec-3fdd96897d5a"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f5c5caf0-3d14-5687-5490-10f9e08c90ca"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f5ef0b93-d908-7b18-ad65-880dd51c6bd0"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f6c5b1ce-4ed4-2efd-940f-e6b1b1d28006"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f8ddb734-6806-7ce7-416f-5195a2ee5388"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f9077054-18ba-e918-692d-67b1fb1a6ca2"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f945e658-5880-4bd8-ead9-e8ded65dc1f7"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("f991f366-2be3-7710-454f-a1c55709dc82"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fa0bb3d5-d45f-626f-d7fd-ea2710c3d6b7"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fa274f68-a7a0-ffac-fa25-698752e96505"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fa40a969-49ba-3c57-4c18-ca9d8f23a55b"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fa5eec73-7184-a067-6afc-a2c9c50f0257"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fa9f81d2-f37d-2cad-c1f2-c11a429f4c42"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fb01d005-0df2-f96b-6b16-888c2faba024"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fc60c61e-aa51-ed9a-6b27-96e0b97944a6"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fd95c0d0-94d7-9d1a-218c-51028bc16aed"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fe3fb2ca-8e78-6619-9133-97657210b408"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fee5e2aa-9ad4-e281-a319-4f387d2af565"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("fef1472e-e9b6-3672-c7e8-aa9f88108aac"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ff6224cb-f1f8-0f42-d7f3-a563359a4120"));

            migrationBuilder.DeleteData(
                table: "Centers",
                keyColumn: "Id",
                keyValue: new Guid("ffd6811f-e33a-288c-4638-de6b5fc764e4"));
        }
    }
}
