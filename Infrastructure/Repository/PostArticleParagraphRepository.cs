using Core.Contracts.Repositories;
using Infrastructure.Persistence;


namespace Infrastructure.Repository
{
	public class PostArticleParagraphRepository : GenericRepository<IApplicationDbContext, PostArticleParagraph>, IPostArticleParagraphRepository
	{
		public PostArticleParagraphRepository(IApplicationDbContext context) : base(context)
		{
		}
	}
}
