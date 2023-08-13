namespace Infrastructure.Services.Contracts
{
	public interface IGalleryService
	{
		Task<bool> Create(GalleryCreateDto Dto);

		Task<bool> Update(GalleryUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<GalleryDto>> GetAll(DateTime? FromDate, DateTime? ToDate, string q = "", int page = 1, int size = 10);
		Task<PaginatedList<GalleryDto>> GetAllWithItems(string q = "", int page = 0,int size =10);

		Task<GalleryDto> GetById(string Id);
		Task<GalleryDto> GetByArName(string Name);
		Task<GalleryDto> GetByEnName(string Name);
        Task<GalleryDto> GetByIdWithItems(string Id);

		Task<GalleryUpdateDto> GetUpdateInfo(string Id);

        Task<bool> CreateGalleryItem(GalleryItemCreateDto Dto);

        Task<bool> DeleteGalleryItem(string Id);
    }
}
