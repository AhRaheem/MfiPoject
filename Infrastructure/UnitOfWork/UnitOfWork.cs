
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
