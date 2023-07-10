using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class RelatedWebsiteRepository : GenericRepository<IApplicationDbContext, RelatedWebsite>, IRelatedWebsiteRepository
	{
		public RelatedWebsiteRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
