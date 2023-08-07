using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class PostServiceParagraphRepository : GenericRepository<IApplicationDbContext, PostServiceParagraph>, IPostServiceParagraphRepository
	{
		public PostServiceParagraphRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
