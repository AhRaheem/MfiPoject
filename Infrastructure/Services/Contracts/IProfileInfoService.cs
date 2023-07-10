
namespace Infrastructure.Services.Contracts
{
	public interface IProfileInfoService
	{
		Task<bool> Create(ProfileInfoCreateDto Dto);

		Task<bool> Update(ProfileInfoUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<IEnumerable<ProfileInfoDto>> GetAll(string? q);

		Task<ProfileInfoDto> GetById(string Id);
        Task<ProfileInfoDto> GetByName(string Name);

        Task<ProfileInfoUpdateDto> GetUpdateInfo(string Id);
    }
}
