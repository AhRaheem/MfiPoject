
using Infrastructure.Services.Contracts;

namespace Infrastructure.Services
{
	public class UserService : IUserService
	{
		public readonly UserManager<ApplicationUser> _UsrMngr;
        private readonly SignInManager<ApplicationUser> _sgnMngr;

        private readonly IMapper _mapper;

		public UserService(IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager)
		{
			_UsrMngr = userManager;
			_sgnMngr = signManager;
			_mapper = mapper;
		}

		public async Task<bool> Create(UserCreateDto Dto)
		{
			var Usr = _mapper.Map<ApplicationUser>(Dto);
			var Rslt = await _UsrMngr.CreateAsync(Usr, Dto.Password);
			if (Rslt != IdentityResult.Success)
				return false;
			if (Dto.IsAdmin)
				await _UsrMngr.AddToRoleAsync(Usr, RolesType.Admin.ToString());
			if (Dto.IsGalleryPublisher)
				await _UsrMngr.AddToRoleAsync(Usr, RolesType.GalleryPublisher.ToString());
			if (Dto.IsGalleryEditor)
				await _UsrMngr.AddToRoleAsync(Usr, RolesType.GalleryEditor.ToString());
			if (Dto.IsNewsPublisher)
				await _UsrMngr.AddToRoleAsync(Usr, RolesType.NewsPublisher.ToString());
			if (Dto.IsNewsEditor)
				await _UsrMngr.AddToRoleAsync(Usr, RolesType.NewsEditor.ToString());
			return true;
		}

		public async Task<bool> Delete(string Id)
		{
			var Usr = await _UsrMngr.FindByIdAsync(Id);
			var Rslt = await _UsrMngr.DeleteAsync(Usr);
			return Rslt == IdentityResult.Success;
		}

		public async Task<PaginatedList<UserDto>> GetAll(string q = "", int page = 0, int size = 10)
		{
			var Usrs = _UsrMngr.Users;
			return await Usrs.ProjectTo<UserDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<UserDto> GetById(string Id)
		{
			return _mapper.Map<UserDto>(await _UsrMngr.FindByIdAsync(Id));
		}

        public async Task<UserDto> GetByName(string Name)
        {
            return _mapper.Map<UserDto>(await _UsrMngr.FindByNameAsync(Name));
        }

        public async Task<UserDto> GetByEmail(string Email)
        {
            return _mapper.Map<UserDto>(await _UsrMngr.FindByEmailAsync(Email));
        }

        public async Task<ApplicationUser> GetByNameAndPassword(string UserName, string Password)
		{
			var Usr = await _UsrMngr.FindByNameAsync(UserName);
			if (Usr is null)
				return null;
			var PasswordCorrect = await _UsrMngr.CheckPasswordAsync(Usr, Password);
			if (!PasswordCorrect)
				return null;
			return Usr;
		}

		public async Task<bool> PasswordSignInAsync(LoginViewModel model) 
		{
			var Rslt = await _sgnMngr.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
			return Rslt.Succeeded;
		}

		public async Task SignOutAsync() 
		{
			await _sgnMngr.SignOutAsync();
		}


        public async Task<bool> Update(UserUpdateDto Dto)
		{
			var Rslt = await _UsrMngr.UpdateAsync(_mapper.Map<ApplicationUser>(Dto));
			return Rslt == IdentityResult.Success;
		}

		public async Task<bool> ForceChangeUserPassword(string UsrId, string NewPassword) 
		{
			var Usr = await _UsrMngr.FindByIdAsync(UsrId);
			Usr.PasswordHash = _UsrMngr.PasswordHasher.HashPassword(Usr, NewPassword);
			var result = await _UsrMngr.UpdateAsync(Usr);
			return result.Succeeded;
		}
	}
}
