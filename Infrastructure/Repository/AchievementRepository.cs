using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class AchievementRepository : GenericRepository<IApplicationDbContext, Achievement>, IAchievementRepository
	{
		public AchievementRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
