

using Infrastructure.Dtos.Service;

namespace Infrastructure.Services.Contracts
{
	public interface IServiceService
	{
		Task<bool> Create(ServiceCreateDto Dto);

		Task<bool> Update(ServiceUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<ServiceDto>> GetAll(string q= "", int page = 0, int size = 10);

		Task<ServiceDto> GetById(string Id);
        Task<ServiceDto> GetByArName(string Name);
        Task<ServiceDto> GetByEnName(string Name);

        Task<ServiceUpdateDto> GetUpdateInfo(string Id);
        Task<List<ServiceDto>> GetTittled();
        Task<List<ServiceDto>> GetBannered();

    }
}
