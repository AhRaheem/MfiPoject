

using Infrastructure.Dtos.Directors;

namespace Infrastructure.Services.Contracts
{
	public interface IDirectorsService
	{
		Task<bool> Create(DirectorsCreateDto Dto);

		Task<bool> Update(DirectorsUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<DirectorsDto>> GetAll(string q= "", int page = 0, int size = 10);

		Task<DirectorsDto> GetById(string Id);
        Task<DirectorsDto> GetByArName(string Name);
        Task<DirectorsDto> GetByEnName(string Name);

        Task<DirectorsUpdateDto> GetUpdateInfo(string Id);

    }
}
