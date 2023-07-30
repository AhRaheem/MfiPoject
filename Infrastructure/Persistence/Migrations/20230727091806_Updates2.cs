using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class Updates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisionWord",
                table: "AboutUs",
                newName: "VisionWordEn");

            migrationBuilder.RenameColumn(
                name: "VisionImage",
                table: "AboutUs",
                newName: "VisionWordAr");

            migrationBuilder.RenameColumn(
                name: "MissionWord",
                table: "AboutUs",
                newName: "VisionImageId");

            migrationBuilder.RenameColumn(
                name: "MissionImage",
                table: "AboutUs",
                newName: "MissionWordEn");

            migrationBuilder.RenameColumn(
                name: "MainPageIntroWord",
                table: "AboutUs",
                newName: "MissionWordAr");

            migrationBuilder.RenameColumn(
                name: "IntroWord",
                table: "AboutUs",
                newName: "MissionImageId");

            migrationBuilder.RenameColumn(
                name: "BeneficiariesWord",
                table: "AboutUs",
                newName: "BeneficiariesWordEn");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiariesWordAr",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiariesWordAr",
                table: "AboutUs");

            migrationBuilder.RenameColumn(
                name: "VisionWordEn",
                table: "AboutUs",
                newName: "VisionWord");

            migrationBuilder.RenameColumn(
                name: "VisionWordAr",
                table: "AboutUs",
                newName: "VisionImage");

            migrationBuilder.RenameColumn(
                name: "VisionImageId",
                table: "AboutUs",
                newName: "MissionWord");

            migrationBuilder.RenameColumn(
                name: "MissionWordEn",
                table: "AboutUs",
                newName: "MissionImage");

            migrationBuilder.RenameColumn(
                name: "MissionWordAr",
                table: "AboutUs",
                newName: "MainPageIntroWord");

            migrationBuilder.RenameColumn(
                name: "MissionImageId",
                table: "AboutUs",
                newName: "IntroWord");

            migrationBuilder.RenameColumn(
                name: "BeneficiariesWordEn",
                table: "AboutUs",
                newName: "BeneficiariesWord");
        }
    }
}
