using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddUserWhoMakeToMainDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "RelatedWebsites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "RelatedWebsites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "RelatedWebsites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ProfileInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "ProfileInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ProfileInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PostParagraphs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "PostParagraphs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "PostParagraphs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PostAffiliateLaws",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "PostAffiliateLaws",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "PostAffiliateLaws",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PartnerCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "PartnerCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "PartnerCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "GalleryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "GalleryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "GalleryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Galleries",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RelatedWebsites");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "RelatedWebsites");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "RelatedWebsites");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProfileInfos");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "ProfileInfos");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ProfileInfos");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PostParagraphs");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "PostParagraphs");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "PostParagraphs");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PostAffiliateLaws");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "PostAffiliateLaws");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "PostAffiliateLaws");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PartnerCategories");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "PartnerCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "PartnerCategories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Galleries");
        }
    }
}
