

using Infrastructure.Dtos.NewsRelatedGallery;

namespace Infrastructure.Services.Contracts
{
	public interface INewsRelatedGalleryService
	{
		Task<bool> Create(NewsRelatedGalleryCreateDto Dto);

		Task<bool> Update(NewsRelatedGalleryUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<NewsRelatedGalleryDto>> GetAll(string q= "", int page = 1, int size = 10);

		Task<NewsRelatedGalleryDto> GetById(string Id);
        Task<NewsRelatedGalleryDto> GetByArName(string Name);
        Task<NewsRelatedGalleryDto> GetByEnName(string Name);

        Task<NewsRelatedGalleryUpdateDto> GetUpdateInfo(string Id);

    }
}
