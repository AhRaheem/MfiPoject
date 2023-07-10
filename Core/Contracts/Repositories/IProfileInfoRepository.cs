

using Core.Persistence;

namespace Core.Contracts.Repositories
{
	public interface IProfileInfoRepository : IGenericRepository<IApplicationDbContext, ProfileInfo>
	{
	}
}
