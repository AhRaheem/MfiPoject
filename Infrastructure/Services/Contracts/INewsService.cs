﻿

using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Service;

namespace Infrastructure.Services.Contracts
{
	public interface INewsService
	{
		Task<bool> Create(NewsCreateDto Dto);

		Task<bool> Update(NewsUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<NewsDto>> GetAll(DateTime? FromDate = null, DateTime? ToDate = null, string q = "", int page = 1, int size = 10);

		Task<NewsDto> GetById(string Id);
        Task<NewsDto> GetByArName(string Name);
        Task<NewsDto> GetByEnName(string Name);

        Task<NewsUpdateDto> GetUpdateInfo(string Id);
        Task<List<NewsDto>> GetTittled();
        Task<List<NewsDto>> GetBannered();
        Task<List<NewsDto>> GetHomeNews();
    }
}
