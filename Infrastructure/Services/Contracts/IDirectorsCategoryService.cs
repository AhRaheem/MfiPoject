

using Infrastructure.Dtos.DirectorsCategory;

namespace Infrastructure.Services.Contracts
{
	public interface IDirectorsCategoryService
	{
		Task<bool> Create(DirectorsCategoryCreateDto Dto);

		Task<bool> Update(DirectorsCategoryUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<DirectorsCategoryDto>> GetAll(string q= "", int page = 1, int size = 10);
		Task<PaginatedList<DirectorsCategoryDto>> GetAllWithSubData(string q= "", int page = 1, int size = 10);

		Task<DirectorsCategoryDto> GetById(string Id);
        Task<DirectorsCategoryDto> GetByArName(string Name);
        Task<DirectorsCategoryDto> GetByEnName(string Name);

        Task<DirectorsCategoryUpdateDto> GetUpdateInfo(string Id);

    }
}
