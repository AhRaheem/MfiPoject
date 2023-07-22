
namespace Core.Persistence
{
    public interface IApplicationDbContext : IDbContext
    {
        DbSet<Gallery> Galleries { get; }
        DbSet<GalleryItem> GalleryItems { get; }
        DbSet<Partner> Partners { get; }
        DbSet<PartnerCategory> PartnerCategories { get; }
        //DbSet<Post> Posts { get; }
        //DbSet<PostArticlePostParagraph> PostParagraphs { get; }
        DbSet<PostAffiliateLaw> PostAffiliateLaws { get; }
        DbSet<ProfileInfo> ProfileInfos { get; }
        DbSet<RelatedWebsite> RelatedWebsites { get; }


        DbSet<Achievement> Achievements { get; }
        DbSet<News> News { get; }
        DbSet<Service> Services { get; }
        DbSet<NewsRelatedGallery> NewsRelatedGalleries { get; }
        DbSet<NewsRelatedNews> NewsRelatedNews { get; }
        DbSet<PostArticleParagraph> PostArticleParagraphs { get; }
        DbSet<PostServiceParagraph> PostServiceParagraphs { get; }
        DbSet<PostServiceParagraphImage> PostServiceParagraphImages { get; }

        DbSet<AboutUs> AboutUs { get; }
        DbSet<Directors> Directors { get; }
        DbSet<DirectorsCategory> DirectorsCategories { get; }


    }
}
