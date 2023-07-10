using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class PartnerCategoryRepository : GenericRepository<IApplicationDbContext, PartnerCategory>, IPartnerCategoryRepository
	{
		public PartnerCategoryRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
