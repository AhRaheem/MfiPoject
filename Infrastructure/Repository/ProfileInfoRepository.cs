using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class ProfileInfoRepository : GenericRepository<IApplicationDbContext, ProfileInfo>, IProfileInfoRepository
	{
		public ProfileInfoRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
