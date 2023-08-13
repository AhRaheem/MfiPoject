

using Infrastructure.Dtos.Achievement;
using Infrastructure.Dtos.Service;

namespace Infrastructure.Services.Contracts
{
	public interface IAchievementService
	{
		Task<bool> Create(AchievementCreateDto Dto);

		Task<bool> Update(AchievementUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<AchievementDto>> GetAll(string q= "", DateTime? FromDate, DateTime? ToDate, int page = 1, int size = 10);

		Task<AchievementDto> GetById(string Id);
        Task<AchievementDto> GetByArName(string Name);
        Task<AchievementDto> GetByEnName(string Name);

        Task<AchievementUpdateDto> GetUpdateInfo(string Id);
        Task<List<AchievementDto>> GetTittled();
        Task<List<AchievementDto>> GetBannered();
    }
}
