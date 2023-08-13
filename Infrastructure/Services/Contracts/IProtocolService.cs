

using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Protocol;
using Infrastructure.Dtos.Service;

namespace Infrastructure.Services.Contracts
{
	public interface IProtocolService
	{
		Task<bool> Create(ProtocolCreateDto Dto);

		Task<bool> Update(ProtocolUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<ProtocolDto>> GetAll(DateTime? FromDate = null, DateTime? ToDate = null, string q = "", int page = 1, int size = 10);

		Task<ProtocolDto> GetById(string Id);
        Task<ProtocolDto> GetByArName(string Name);
        Task<ProtocolDto> GetByEnName(string Name);

        Task<ProtocolUpdateDto> GetUpdateInfo(string Id);
        Task<List<ProtocolDto>> GetTittled();
        Task<List<ProtocolDto>> GetBannered();

    }
}
