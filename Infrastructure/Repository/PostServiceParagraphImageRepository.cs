using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class PostServiceParagraphImageRepository : GenericRepository<IApplicationDbContext, PostServiceParagraphImage>, IPostServiceParagraphImageRepository
	{
		public PostServiceParagraphImageRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
