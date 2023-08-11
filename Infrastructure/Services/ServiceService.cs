

using Infrastructure.Dtos.Service;

namespace Infrastructure.Services
{
	public class ServiceService : IServiceService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public ServiceService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(ServiceCreateDto Dto)
		{
			Dto.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Service.Add(_mapper.Map<Service>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.Service.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.MainFileId);
			await _unitOfWork.Service.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<ServiceDto>> GetAll(string q = "", int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.Service.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			return await Qry.ProjectTo<ServiceDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<ServiceDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.Service.GetById(Id);
			return _mapper.Map<ServiceDto>(Entity);
		}

		public async Task<bool> Update(ServiceUpdateDto Dto)
		{
			var Entity = _mapper.Map<Service>(Dto);
			if (Dto.File != null)
				Entity.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Service.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<ServiceUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<ServiceUpdateDto>(await _unitOfWork.Service.GetById(Id));
        }

        public async Task<ServiceDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.Service.Get(x => x.TitleAr == Name);
            return _mapper.Map<ServiceDto>(Entity);
        }

        public async Task<ServiceDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.Service.Get(x => x.TitleEn == Name);
            return _mapper.Map<ServiceDto>(Entity);
        }

        public async Task<List<ServiceDto>> GetTittled()
        {
			var Entities = await _unitOfWork.Service.GetAll(x => x.Titled);
			return _mapper.Map<List<ServiceDto>>(Entities);
        }

        public async Task<List<ServiceDto>> GetBannered()
        {
            var Entities = await _unitOfWork.Service.GetAll(x => x.Bannerpost);
            return _mapper.Map<List<ServiceDto>>(Entities);
        }
    }
}
