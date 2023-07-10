using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class RemoveSortNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortNum",
                table: "PostParagraphs");

            migrationBuilder.DropColumn(
                name: "SortNum",
                table: "GalleryItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortNum",
                table: "PostParagraphs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortNum",
                table: "GalleryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
