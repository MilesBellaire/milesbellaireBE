using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MbCore.Migrations
{
    /// <inheritdoc />
    public partial class AddingLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Experience");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Experience",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Experience");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Experience",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
