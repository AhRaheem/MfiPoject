using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class NewsRepository : GenericRepository<IApplicationDbContext, News>, INewsRepository
	{
		public NewsRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
