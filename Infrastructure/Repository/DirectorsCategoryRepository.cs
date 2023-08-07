using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class DirectorsCategoryRepository : GenericRepository<IApplicationDbContext, DirectorsCategory>, IDirectorsCategoryRepository
	{
		public DirectorsCategoryRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
