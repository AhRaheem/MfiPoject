using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddCeosName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProtocolId",
                table: "PostArticleParagraphs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CeoNameAr",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CeoNameEn",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChairmanAr",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChairmanEn",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostArticleParagraphs_ProtocolId",
                table: "PostArticleParagraphs",
                column: "ProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostArticleParagraphs_Post_ProtocolId",
                table: "PostArticleParagraphs",
                column: "ProtocolId",
                principalTable: "Post",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostArticleParagraphs_Post_ProtocolId",
                table: "PostArticleParagraphs");

            migrationBuilder.DropIndex(
                name: "IX_PostArticleParagraphs_ProtocolId",
                table: "PostArticleParagraphs");

            migrationBuilder.DropColumn(
                name: "ProtocolId",
                table: "PostArticleParagraphs");

            migrationBuilder.DropColumn(
                name: "CeoNameAr",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "CeoNameEn",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ChairmanAr",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ChairmanEn",
                table: "AboutUs");
        }
    }
}
