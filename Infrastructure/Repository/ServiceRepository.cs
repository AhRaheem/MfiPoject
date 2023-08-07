using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class ServiceRepository : GenericRepository<IApplicationDbContext, Service>, IServiceRepository
	{
		public ServiceRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
