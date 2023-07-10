

using Core.Models;
using Core.Persistence;

namespace Core.Contracts.Repositories
{
	public interface IGalleryRepository : IGenericRepository<IApplicationDbContext, Gallery>
	{
        Task CreateGalleryItem(GalleryItem Entity);

        Task DeleteGalleryItem(GalleryItem Entity);

        Task UpdateGalleryItem(GalleryItem Entity);

        Task SortGalleryItems(List<SortModel> Entities);

        Task<IEnumerable<GalleryItem>> GetItems(string GalleryId);

        Task<GalleryItem> GetItem(string Id);
    }
}
