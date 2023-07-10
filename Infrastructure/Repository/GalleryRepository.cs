using Core.Contracts.Repositories;
using ImageMagick;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
	public class GalleryRepository : GenericRepository<IApplicationDbContext,Gallery>, IGalleryRepository
	{
		public GalleryRepository(IApplicationDbContext context) : base(context)
		{
		}

        public async Task CreateGalleryItem(GalleryItem Entity)
        {
            await _dbContext.GalleryItems.AddAsync(Entity);
        }

        public async Task DeleteGalleryItem(GalleryItem Entity)
        {
            Entity.IsDeleted = true;
            Entity.DeletedOn = DateTime.Now;
            await UpdateGalleryItem(Entity);
        }

        public async Task<GalleryItem> GetItem(string Id)
        {
            return await _dbContext.GalleryItems.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<GalleryItem>> GetItems(string GalleryId)
        {
            return await _dbContext.GalleryItems.OrderByDescending(x => x.CreatedOn).ToListAsync();
        }

        public Task SortGalleryItems(List<SortModel> Entities)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGalleryItem(GalleryItem Entity)
        {
            await Task.Run(() => { _dbContext.GalleryItems.Update(Entity); });
        }
    }
}
