using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove0statefrommissingthing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "MissingThings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "MissingThings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
