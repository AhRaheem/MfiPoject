

using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Service;

namespace Infrastructure.Services.Contracts
{
	public interface INewsService
	{
		Task<bool> Create(NewsCreateDto Dto);

		Task<bool> Update(NewsUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<NewsDto>> GetAll(string q= "", int page = 0, int size = 10);

		Task<NewsDto> GetById(string Id);
        Task<NewsDto> GetByArName(string Name);
        Task<NewsDto> GetByEnName(string Name);

        Task<NewsUpdateDto> GetUpdateInfo(string Id);
        Task<List<NewsDto>> GetTittled();
        Task<List<NewsDto>> GetBannered();
    }
}
