

namespace Infrastructure.Services.Contracts
{
	public interface IUserService
	{
		Task<bool> Create(UserCreateDto Dto);

		Task<bool> Update(UserUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<UserDto>> GetAll(string q= "", int page = 0, int size = 10);

		Task<UserDto> GetById(string Id);
		Task<UserDto> GetByName(string Name);
		Task<UserDto> GetByEmail(string Email);

        Task<ApplicationUser> GetByNameAndPassword(string UserName, string Password);
		Task<bool> PasswordSignInAsync(LoginViewModel model);
		Task SignOutAsync();
		Task<bool> ForceChangeUserPassword(string UsrId, string NewPassword);

	}
}
