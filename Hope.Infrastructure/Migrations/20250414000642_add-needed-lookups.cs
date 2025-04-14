using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addneededlookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GovernmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Governments",
                columns: new[] { "Id", "NameAr", "NameEn", "PhoneCode" },
                values: new object[,]
                {
                    { 1, "القاهرة", "Cairo", "02" },
                    { 2, "الإسكندرية", "Alexandria", "03" },
                    { 3, "الجيزة", "Giza", "02" },
                    { 4, "القليوبية", "Qalyubia", "013" },
                    { 5, "بورسعيد", "Port Said", "066" },
                    { 6, "السويس", "Suez", "062" },
                    { 7, "الأقصر", "Luxor", "095" },
                    { 8, "أسوان", "Aswan", "097" },
                    { 9, "أسيوط", "Assiut", "088" },
                    { 10, "البحيرة", "Beheira", "045" },
                    { 11, "بني سويف", "Beni Suef", "082" },
                    { 12, "الدقهلية", "Dakahlia", "050" },
                    { 13, "دمياط", "Damietta", "057" },
                    { 14, "الفيوم", "Faiyum", "084" },
                    { 15, "الغربية", "Gharbia", "040" },
                    { 16, "الإسماعيلية", "Ismailia", "064" },
                    { 17, "كفر الشيخ", "Kafr El Sheikh", "047" },
                    { 18, "مطروح", "Matruh", "046" },
                    { 19, "المنيا", "Minya", "086" },
                    { 20, "المنوفية", "Monufia", "048" },
                    { 21, "الوادي الجديد", "New Valley", "092" },
                    { 22, "شمال سيناء", "North Sinai", "068" },
                    { 23, "قنا", "Qena", "096" },
                    { 24, "البحر الأحمر", "Red Sea", "065" },
                    { 25, "الشرقية", "Sharqia", "055" },
                    { 26, "سوهاج", "Sohag", "093" },
                    { 27, "جنوب سيناء", "South Sinai", "069" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GovernmentId",
                table: "AspNetUsers",
                column: "GovernmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Governments_GovernmentId",
                table: "AspNetUsers",
                column: "GovernmentId",
                principalTable: "Governments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Governments_GovernmentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Governments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GovernmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GovernmentId",
                table: "AspNetUsers");
        }
    }
}
