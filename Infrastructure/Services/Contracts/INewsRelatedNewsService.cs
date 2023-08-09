

using Infrastructure.Dtos.NewsRelatedNews;

namespace Infrastructure.Services.Contracts
{
	public interface INewsRelatedNewsService
	{
		Task<bool> Create(NewsRelatedNewsCreateDto Dto);

		Task<bool> Update(NewsRelatedNewsUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<NewsRelatedNewsDto>> GetAll(string q= "", int page = 0, int size = 10);

		Task<NewsRelatedNewsDto> GetById(string Id);
        Task<NewsRelatedNewsDto> GetByArName(string Name);
        Task<NewsRelatedNewsDto> GetByEnName(string Name);

        Task<NewsRelatedNewsUpdateDto> GetUpdateInfo(string Id);

    }
}
