using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class AboutUsRepository : GenericRepository<IApplicationDbContext, AboutUs>, IAboutusRepository
	{
		public AboutUsRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
