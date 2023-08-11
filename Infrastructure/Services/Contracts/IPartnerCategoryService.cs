

namespace Infrastructure.Services.Contracts
{
	public interface IPartnerCategoryService
	{
		Task<bool> Create(PartnerCategoryCreateDto Dto);

		Task<bool> Update(PartnerCategoryUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<PartnerCategoryDto>> GetAll(string q= "", int page = 1, int size = 10);

		Task<PartnerCategoryDto> GetById(string Id);
        Task<PartnerCategoryDto> GetByArName(string Name);
        Task<PartnerCategoryDto> GetByEnName(string Name);

        Task<IEnumerable<PartnerCategoryDto>> GetList();

    }
}
