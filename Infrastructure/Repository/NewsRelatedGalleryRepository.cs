using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class NewsRelatedGalleryRepository : GenericRepository<IApplicationDbContext, NewsRelatedGallery>, INewsRelatedGalleryRepository
	{
		public NewsRelatedGalleryRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
