using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class FileRepository : GenericRepository<IFileDbContext,Core.Entites.File>, IFileRepository
	{
		public FileRepository(IFileDbContext context) : base(context)
		{
		}
	}
}
