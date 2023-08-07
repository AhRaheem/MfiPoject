
using Core.Contracts.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        readonly IApplicationDbContext Context;
        readonly IFileDbContext FileContext;

        private IGalleryRepository _Gallery;
        public IGalleryRepository Gallery { get { return _Gallery ?? (new GalleryRepository(Context)); } }

        private IPartnerCategoryRepository _PartnerCategory;
        public IPartnerCategoryRepository PartnerCategory { get { return _PartnerCategory ?? (new PartnerCategoryRepository(Context)); } }

        private IPartnerRepository _Partner;
        public IPartnerRepository Partner { get { return _Partner ?? (new PartnerRepository(Context)); } }

        //private IPostRepository _Post;
        //public IPostRepository Post { get { return _Post ?? (new PostRepository(Context)); } }

        private IProfileInfoRepository _ProfileInfo;
        public IProfileInfoRepository ProfileInfo { get { return _ProfileInfo ?? (new ProfileInfoRepository(Context)); } }

        private IRelatedWebsiteRepository _RelatedWebsite;
        public IRelatedWebsiteRepository RelatedWebsite { get { return _RelatedWebsite ?? (new RelatedWebsiteRepository(Context)); } }

        private IFileRepository _File;
        public IFileRepository File { get { return _File ?? (new FileRepository(FileContext)); } }

        private IAboutusRepository _AboutUs;
        public IAboutusRepository AboutUs { get { return _AboutUs ?? (new AboutUsRepository(Context)); } }

        private IAchievementRepository _Achievement;
        public IAchievementRepository Achievement { get { return _Achievement ?? (new AchievementRepository(Context)); } }

        private INewsRepository _News;
        public INewsRepository News { get { return _News ?? (new NewsRepository(Context)); } }

        private IServiceRepository _Service;
        public IServiceRepository Service { get { return _Service ?? (new ServiceRepository(Context)); } }

        private INewsRelatedGalleryRepository _NewsRelatedGallery;
        public INewsRelatedGalleryRepository NewsRelatedGallery { get { return _NewsRelatedGallery ?? (new NewsRelatedGalleryRepository(Context)); } }

        private INewsRelatedNewsRepository _NewsRelatedNews;
        public INewsRelatedNewsRepository NewsRelatedNews { get { return _NewsRelatedNews ?? (new NewsRelatedNewsRepository(Context)); } }

        private IPostArticleParagraphRepository _PostArticleParagraph;
        public IPostArticleParagraphRepository PostArticleParagraph { get { return _PostArticleParagraph ?? (new PostArticleParagraphRepository(Context)); } }

        private IPostServiceParagraphRepository _PostServiceParagraph;
        public IPostServiceParagraphRepository PostServiceParagraph { get { return _PostServiceParagraph ?? (new PostServiceParagraphRepository(Context)); } }

        private IPostServiceParagraphImageRepository _PostServiceParagraphImage;
        public IPostServiceParagraphImageRepository PostServiceParagraphImage { get { return _PostServiceParagraphImage ?? (new PostServiceParagraphImageRepository(Context)); } }

        private IDirectorsRepository _Director;
        public IDirectorsRepository Directors { get { return _Director ?? (new DirectorRepository(Context)); } }

        private IDirectorsCategoryRepository _DirectorsCategory;
        public IDirectorsCategoryRepository DirectorsCategory { get { return _DirectorsCategory ?? (new DirectorsCategoryRepository(Context)); } }

        public UnitOfWork(IApplicationDbContext dbContext, IFileDbContext FileDbContext)
		{
			Context = dbContext;
            FileContext = FileDbContext;
		}

		public async Task<int> Save(CancellationToken cancellationToken = default)
        {
            var SavedChanges = 0;
            if (Context.HasUnsavedChanges())
                SavedChanges += await Context.SaveChangesAsync(cancellationToken);
            if (FileContext.HasUnsavedChanges())
                SavedChanges += await FileContext.SaveChangesAsync(cancellationToken);
            return SavedChanges;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }

    }
}
