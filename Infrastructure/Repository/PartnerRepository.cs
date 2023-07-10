using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class PartnerRepository : GenericRepository<IApplicationDbContext, Partner>, IPartnerRepository
	{
		public PartnerRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
