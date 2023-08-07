using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class NewsRelatedNewsRepository : GenericRepository<IApplicationDbContext, NewsRelatedNews>, INewsRelatedNewsRepository
	{
		public NewsRelatedNewsRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
