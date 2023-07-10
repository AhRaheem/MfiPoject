
namespace Core.Persistence
{
    public interface IApplicationDbContext : IDbContext
    {
        DbSet<Gallery> Galleries { get; }
        DbSet<GalleryItem> GalleryItems { get; }
        DbSet<Partner> Partners { get; }
        DbSet<PartnerCategory> PartnerCategories { get; }
        DbSet<Post> Posts { get; }
        DbSet<PostParagraph> PostParagraphs { get; }
        DbSet<PostAffiliateLaw> PostAffiliateLaws { get; }
        DbSet<ProfileInfo> ProfileInfos { get; }
        DbSet<RelatedWebsite> RelatedWebsites { get; }
	}
}
