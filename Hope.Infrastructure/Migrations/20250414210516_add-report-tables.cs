using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addreporttables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Centers_Governments_GovernmentId",
                        column: x => x.GovernmentId,
                        principalTable: "Governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportType = table.Column<int>(type: "int", nullable: false),
                    ReportSubjectType = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GovernmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Governments_GovernmentId",
                        column: x => x.GovernmentId,
                        principalTable: "Governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MissingPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissingPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissingPersons_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissingThings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissingThings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissingThings_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissingPersonImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissingPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissingPersonImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissingPersonImages_MissingPersons_MissingPersonId",
                        column: x => x.MissingPersonId,
                        principalTable: "MissingPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissingThingImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissingThingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissingThingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissingThingImages_MissingThings_MissingThingId",
                        column: x => x.MissingThingId,
                        principalTable: "MissingThings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_GovernmentId",
                table: "Centers",
                column: "GovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MissingPersonImages_MissingPersonId",
                table: "MissingPersonImages",
                column: "MissingPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MissingPersons_ReportId",
                table: "MissingPersons",
                column: "ReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MissingThingImages_MissingThingId",
                table: "MissingThingImages",
                column: "MissingThingId");

            migrationBuilder.CreateIndex(
                name: "IX_MissingThings_ReportId",
                table: "MissingThings",
                column: "ReportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CenterId",
                table: "Reports",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_GovernmentId",
                table: "Reports",
                column: "GovernmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissingPersonImages");

            migrationBuilder.DropTable(
                name: "MissingThingImages");

            migrationBuilder.DropTable(
                name: "MissingPersons");

            migrationBuilder.DropTable(
                name: "MissingThings");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Centers");
        }
    }
}
