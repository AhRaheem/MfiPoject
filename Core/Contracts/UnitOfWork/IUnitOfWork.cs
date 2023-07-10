using Core.Contracts.Repositories;

namespace Core.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
	{
        IFileRepository File { get; }
        IGalleryRepository Gallery { get; }
        IPartnerCategoryRepository PartnerCategory { get; }
        IPartnerRepository Partner { get; }
        IPostRepository Post { get; }
        IProfileInfoRepository ProfileInfo { get; }
        IRelatedWebsiteRepository RelatedWebsite { get; }
        Task<int> Save(CancellationToken cancellationToken = default);
    }
}
