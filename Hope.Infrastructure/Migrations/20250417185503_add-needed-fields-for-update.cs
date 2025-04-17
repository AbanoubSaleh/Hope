using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addneededfieldsforupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MissingThings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MissingThings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MissingPersons",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MissingThings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MissingThings");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MissingPersons");
        }
    }
}
