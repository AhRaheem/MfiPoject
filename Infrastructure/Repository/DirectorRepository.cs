using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class DirectorRepository : GenericRepository<IApplicationDbContext, Directors>, IDirectorsRepository
	{
		public DirectorRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
