using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MbCore.Migrations
{
    /// <inheritdoc />
    public partial class SeparatingExperiences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentPosition",
                table: "Experience",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Experience",
                type: "varchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Experience",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Experience",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Experience",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPosition",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Experience");
        }
    }
}
