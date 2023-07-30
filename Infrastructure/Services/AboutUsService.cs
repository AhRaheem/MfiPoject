

using Infrastructure.Dtos.AboutUs;

namespace Infrastructure.Services
{
	public class AboutUsService : IAboutUsService
    {
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public AboutUsService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Update(AboutUsUpdateDto Dto)
		{
			var Entity = _mapper.Map<AboutUs>(Dto);
			await _unitOfWork.AboutUs.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<AboutUsUpdateDto> GetUpdateInfo()
        {
            return _mapper.Map<AboutUsUpdateDto>(await _unitOfWork.AboutUs.Get());
        }
    }
}
