
namespace Infrastructure.Services.Contracts
{
	public interface IRelatedWebsiteService
	{
		Task<bool> Create(RelatedWebsiteCreateDto Dto);

		Task<bool> Update(RelatedWebsiteUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<RelatedWebsiteDto>> GetAll(string q= "", int page = 1, int size = 10);

		Task<RelatedWebsiteDto> GetById(string Id);
        Task<RelatedWebsiteDto> GetByArName(string Name);
        Task<RelatedWebsiteDto> GetByEnName(string Name);

        Task<RelatedWebsiteUpdateDto> GetUpdateInfo(string Id);
        
    }
}
