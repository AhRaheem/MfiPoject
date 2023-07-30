using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddAboutUsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeneficiariesWord",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroWord",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainPageIntroWord",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionImage",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionWord",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisionImage",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisionWord",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiariesWord",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "IntroWord",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "MainPageIntroWord",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "MissionImage",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "MissionWord",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "VisionImage",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "VisionWord",
                table: "AboutUs");
        }
    }
}
