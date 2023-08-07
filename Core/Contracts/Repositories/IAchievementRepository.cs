

using Core.Persistence;

namespace Core.Contracts.Repositories
{
	public interface IAchievementRepository : IGenericRepository<IApplicationDbContext, Achievement>
	{
	}
}
