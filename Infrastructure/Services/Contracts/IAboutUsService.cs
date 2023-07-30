

using Infrastructure.Dtos.AboutUs;

namespace Infrastructure.Services.Contracts
{
	public interface IAboutUsService
	{
		Task<bool> Update(AboutUsUpdateDto Dto);

        Task<AboutUsUpdateDto> GetUpdateInfo();

    }
}
