using Core.Models;
using Core.Persistence;

namespace Core.Contracts.Repositories
{
	public interface IPostRepository : IGenericRepository<IApplicationDbContext, Post>
	{
        Task CreatePostParagraph(PostParagraph Entity);

        Task UpdatePostParagraph(PostParagraph Entity);

        Task DeletePostParagraph(PostParagraph Entity);

        Task SortPostParagraphs(List<SortModel> Entities);

        Task<IEnumerable<PostParagraph>> GetParagraphs(string PostId);

        Task<PostParagraph> GetParagraphById(string Id);
        Task<PostParagraph> GetParagraphByNameAr(string Name);
        Task<PostParagraph> GetParagraphNameEn(string Name);



        Task CreatePostAffiliateLaw(PostAffiliateLaw Entity);

        Task UpdatePostAffiliateLaw(PostAffiliateLaw Entity);

        Task DeletePostAffiliateLaw(PostAffiliateLaw Entity);

        Task SortPostAffiliateLaws(List<SortModel> Entities);

        Task<IEnumerable<PostAffiliateLaw>> GetAffiliateLaws(string PostId);

        Task<PostAffiliateLaw> GetAffiliateLawById(string Id);
        Task<PostAffiliateLaw> GetAffiliateLawByNameEn(string Name);
        Task<PostAffiliateLaw> GetAffiliateLawByNameAr(string Name);
    }
}
