using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class UpdateDirectorsInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionNameAr",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "PositionNameEn",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "Directors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionNameAr",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionNameEn",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleAr",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
