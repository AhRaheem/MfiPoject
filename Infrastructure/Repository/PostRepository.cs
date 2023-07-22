using Core.Contracts.Repositories;
using Core.Entites.Base;
using ImageMagick;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repository
{
 //   public class PostRepository : GenericRepository<IApplicationDbContext, Post>, IPostRepository
	//{
 //       protected readonly IApplicationDbContext _dbContext;

 //       public PostRepository(IApplicationDbContext context) : base(context)
	//	{
 //           _dbContext = context;
	//	}

 //       public async Task CreatePostAffiliateLaw(PostAffiliateLaw Model)
 //       {
 //           await _dbContext.PostAffiliateLaws.AddAsync(Model);
 //       }

 //       public async Task CreatePostParagraph(PostArticlePostParagraph Model)
 //       {
 //           await _dbContext.PostParagraphs.AddAsync(Model);
 //       }

 //       public async Task DeletePostAffiliateLaw(PostAffiliateLaw Entity)
 //       {
 //           Entity.IsDeleted = true;
 //           Entity.DeletedOn = DateTime.Now;
 //           await UpdatePostAffiliateLaw(Entity);
 //       }

 //       public async Task DeletePostParagraph(PostArticlePostParagraph Entity)
 //       {
 //           Entity.IsDeleted = true;
 //           Entity.DeletedOn = DateTime.Now;
 //           await UpdatePostParagraph(Entity);
 //       }

 //       public async Task<PostAffiliateLaw> GetAffiliateLawById(string Id)
 //       {
 //           return await _dbContext.PostAffiliateLaws.FirstOrDefaultAsync(x => x.Id == Id);
 //       }

 //       public async Task<PostAffiliateLaw> GetAffiliateLawByNameAr(string Name)
 //       {
 //           return await _dbContext.PostAffiliateLaws.FirstOrDefaultAsync(x => x.NameAr == Name);
 //       }

 //       public async Task<PostAffiliateLaw> GetAffiliateLawByNameEn(string Name)
 //       {
 //           return await _dbContext.PostAffiliateLaws.FirstOrDefaultAsync(x => x.NameEn == Name);
 //       }

 //       public async Task<IEnumerable<PostAffiliateLaw>> GetAffiliateLaws(string PostId)
 //       {
 //           return await _dbContext.PostAffiliateLaws.OrderByDescending(x => x.CreatedOn).ToListAsync();
 //       }

 //       public async Task<PostArticlePostParagraph> GetParagraphById(string Id)
 //       {
 //           return await _dbContext.PostParagraphs.FirstOrDefaultAsync(x => x.Id == Id);
 //       }

 //       public async Task<PostArticlePostParagraph> GetParagraphByNameAr(string Name)
 //       {
 //           return await _dbContext.PostParagraphs.FirstOrDefaultAsync(x => x.TitleAr == Name);
 //       }

 //       public async Task<PostArticlePostParagraph> GetParagraphNameEn(string Name)
 //       {
 //           return await _dbContext.PostParagraphs.FirstOrDefaultAsync(x => x.TitleEn == Name);
 //       }

 //       public async Task<IEnumerable<PostArticlePostParagraph>> GetParagraphs(string PostId)
 //       {
 //           return await _dbContext.PostParagraphs.OrderByDescending(x => x.CreatedOn).ToListAsync();
 //       }

 //       public Task SortPostAffiliateLaws(List<SortModel> Entities)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       public Task SortPostParagraphs(List<SortModel> Entities)
 //       {
 //           throw new NotImplementedException();
 //       }

 //       public async Task UpdatePostAffiliateLaw(PostAffiliateLaw Entity)
 //       {
 //           await Task.Run(() => { _dbContext.PostAffiliateLaws.Update(Entity); });
 //       }

 //       public async Task UpdatePostParagraph(PostArticlePostParagraph Entity)
 //       {
 //           await Task.Run(() => { _dbContext.PostParagraphs.Update(Entity); });
 //       }
 //   }
}
