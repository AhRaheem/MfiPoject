

namespace Infrastructure.Services.Contracts
{
	public interface IPartnerService
	{
		Task<bool> Create(PartnerCreateDto Dto);

		Task<bool> Update(PartnerUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<PartnerDto>> GetAll(string q= "", int page = 0, int size = 10);

		Task<PartnerDto> GetById(string Id);
        Task<PartnerDto> GetByArName(string Name);
        Task<PartnerDto> GetByEnName(string Name);

        Task<PartnerUpdateDto> GetUpdateInfo(string Id);

    }
}
