using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LataPrzestepne.Migrations
{
    public partial class ps5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HistoryData",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HistoryData");
        }
    }
}
