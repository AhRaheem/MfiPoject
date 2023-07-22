

namespace Infrastructure.Services
{
	public class PartnerService : IPartnerService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public PartnerService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(PartnerCreateDto Dto)
		{
			Dto.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Partner.Add(_mapper.Map<Partner>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.Partner.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.FileId);
			await _unitOfWork.Partner.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<PartnerDto>> GetAll(string q = "", int page = 0, int size = 10)
		{
			var Qry = _unitOfWork.Partner.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.NameAr.Contains(q) || x.NameEn.Contains(q));
			return await Qry.ProjectTo<PartnerDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<PartnerDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.Partner.GetById(Id);
			return _mapper.Map<PartnerDto>(Entity);
		}

		public async Task<bool> Update(PartnerUpdateDto Dto)
		{
			var Entity = _mapper.Map<Partner>(Dto);
			if (Dto.File != null)
				Entity.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Partner.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<PartnerUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<PartnerUpdateDto>(await _unitOfWork.Partner.GetById(Id));
        }

        public async Task<PartnerDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.Partner.Get(x => x.NameAr == Name);
            return _mapper.Map<PartnerDto>(Entity);
        }

        public async Task<PartnerDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.Partner.Get(x => x.NameEn == Name);
            return _mapper.Map<PartnerDto>(Entity);
        }
    }
}
