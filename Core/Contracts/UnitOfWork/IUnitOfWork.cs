using Core.Contracts.Repositories;

namespace Core.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
	{
        IFileRepository File { get; }
        IGalleryRepository Gallery { get; }
        IPartnerCategoryRepository PartnerCategory { get; }
        IPartnerRepository Partner { get; }
        //IPostRepository Post { get; }
        IAchievementRepository Achievement { get; }
        INewsRepository News { get; }
        IServiceRepository Service { get; }
        IProtocolRepository Protocol { get; }
        INewsRelatedGalleryRepository NewsRelatedGallery { get; }
        INewsRelatedNewsRepository NewsRelatedNews { get; }
        IPostArticleParagraphRepository PostArticleParagraph { get; }
        IPostServiceParagraphRepository PostServiceParagraph { get; }
        IPostServiceParagraphImageRepository PostServiceParagraphImage { get; }
        IDirectorsRepository Directors { get; }
        IDirectorsCategoryRepository DirectorsCategory { get; }
        IProfileInfoRepository ProfileInfo { get; }
        IRelatedWebsiteRepository RelatedWebsite { get; }
        IAboutusRepository AboutUs { get; }
        Task<int> Save(CancellationToken cancellationToken = default);
    }
}
