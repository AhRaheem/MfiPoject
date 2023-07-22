using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddLastEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostAffiliateLaws_Posts_PostId",
                table: "PostAffiliateLaws");

            migrationBuilder.DropTable(
                name: "PostParagraphs");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsId",
                table: "PostAffiliateLaws",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainFileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectorsCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostState = table.Column<int>(type: "int", nullable: false),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePost = table.Column<bool>(type: "bit", nullable: false),
                    Bannerpost = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakingFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BreakingTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Titled = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainFileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorsCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AboutUsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directors_AboutUs_AboutUsId",
                        column: x => x.AboutUsId,
                        principalTable: "AboutUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Directors_DirectorsCategories_DirectorsCategoryId",
                        column: x => x.DirectorsCategoryId,
                        principalTable: "DirectorsCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NewsRelatedGalleries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RelatedGalleryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NewsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsRelatedGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsRelatedGalleries_Galleries_RelatedGalleryId",
                        column: x => x.RelatedGalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewsRelatedGalleries_Post_NewsId",
                        column: x => x.NewsId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NewsRelatedNews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RelatedNewsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NewsId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsRelatedNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsRelatedNews_Post_RelatedNewsId",
                        column: x => x.RelatedNewsId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostArticleParagraphs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchievementId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NewsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostArticleParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostArticleParagraphs_Post_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostArticleParagraphs_Post_NewsId",
                        column: x => x.NewsId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostArticleParagraphs_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostArticleParagraphs_Post_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostServiceParagraphs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostServiceParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostServiceParagraphs_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostServiceParagraphImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostServiceParagraphId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostServiceParagraphImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostServiceParagraphImages_Post_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostServiceParagraphImages_PostServiceParagraphs_PostServiceParagraphId",
                        column: x => x.PostServiceParagraphId,
                        principalTable: "PostServiceParagraphs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostAffiliateLaws_AboutUsId",
                table: "PostAffiliateLaws",
                column: "AboutUsId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_AboutUsId",
                table: "Directors",
                column: "AboutUsId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_DirectorsCategoryId",
                table: "Directors",
                column: "DirectorsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsRelatedGalleries_NewsId",
                table: "NewsRelatedGalleries",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsRelatedGalleries_RelatedGalleryId",
                table: "NewsRelatedGalleries",
                column: "RelatedGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsRelatedNews_RelatedNewsId",
                table: "NewsRelatedNews",
                column: "RelatedNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_PostArticleParagraphs_AchievementId",
                table: "PostArticleParagraphs",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_PostArticleParagraphs_NewsId",
                table: "PostArticleParagraphs",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_PostArticleParagraphs_PostId",
                table: "PostArticleParagraphs",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostArticleParagraphs_ServiceId",
                table: "PostArticleParagraphs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PostServiceParagraphImages_PostServiceParagraphId",
                table: "PostServiceParagraphImages",
                column: "PostServiceParagraphId");

            migrationBuilder.CreateIndex(
                name: "IX_PostServiceParagraphImages_ServiceId",
                table: "PostServiceParagraphImages",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PostServiceParagraphs_PostId",
                table: "PostServiceParagraphs",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostAffiliateLaws_AboutUs_AboutUsId",
                table: "PostAffiliateLaws",
                column: "AboutUsId",
                principalTable: "AboutUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostAffiliateLaws_Post_PostId",
                table: "PostAffiliateLaws",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostAffiliateLaws_AboutUs_AboutUsId",
                table: "PostAffiliateLaws");

            migrationBuilder.DropForeignKey(
                name: "FK_PostAffiliateLaws_Post_PostId",
                table: "PostAffiliateLaws");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "NewsRelatedGalleries");

            migrationBuilder.DropTable(
                name: "NewsRelatedNews");

            migrationBuilder.DropTable(
                name: "PostArticleParagraphs");

            migrationBuilder.DropTable(
                name: "PostServiceParagraphImages");

            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "DirectorsCategories");

            migrationBuilder.DropTable(
                name: "PostServiceParagraphs");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropIndex(
                name: "IX_PostAffiliateLaws_AboutUsId",
                table: "PostAffiliateLaws");

            migrationBuilder.DropColumn(
                name: "AboutUsId",
                table: "PostAffiliateLaws");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BreakingFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BreakingTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MainFileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostState = table.Column<int>(type: "int", nullable: false),
                    PostType = table.Column<int>(type: "int", nullable: false),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostParagraphs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostParagraphs_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostParagraphs_PostId",
                table: "PostParagraphs",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostAffiliateLaws_Posts_PostId",
                table: "PostAffiliateLaws",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
