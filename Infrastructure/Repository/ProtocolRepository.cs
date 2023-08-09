using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class ProtocolRepository : GenericRepository<IApplicationDbContext, Protocol>, IProtocolRepository
	{
		public ProtocolRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
