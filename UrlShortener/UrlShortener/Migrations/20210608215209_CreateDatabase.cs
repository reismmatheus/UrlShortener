using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shorteners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shortened = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Full = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shorteners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shorteners_Shortened",
                table: "Shorteners",
                column: "Shortened",
                unique: true,
                filter: "[Shortened] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shorteners");
        }
    }
}
