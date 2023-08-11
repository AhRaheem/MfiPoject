
namespace Infrastructure.Services
{
	public class RelatedWebsiteService : IRelatedWebsiteService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public RelatedWebsiteService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(RelatedWebsiteCreateDto Dto)
		{
			Dto.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.RelatedWebsite.Add(_mapper.Map<RelatedWebsite>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.RelatedWebsite.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.FileId);
			await _unitOfWork.RelatedWebsite.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<RelatedWebsiteDto>> GetAll(string q = "", int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.RelatedWebsite.GetAllQuery(predicate: x=> !x.IsDeleted, page:page,size:size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.NameAr.Contains(q) || x.NameEn.Contains(q));
			return await Qry.ProjectTo<RelatedWebsiteDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<RelatedWebsiteDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.RelatedWebsite.GetById(Id);
			return _mapper.Map<RelatedWebsiteDto>(Entity);
		}

		public async Task<bool> Update(RelatedWebsiteUpdateDto Dto)
		{
			var Entity = _mapper.Map<RelatedWebsite>(Dto);
			if (Dto.File != null)
				Entity.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.RelatedWebsite.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<RelatedWebsiteUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<RelatedWebsiteUpdateDto>(await _unitOfWork.RelatedWebsite.GetById(Id));
        }

        public async Task<RelatedWebsiteDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.RelatedWebsite.Get(x => x.NameAr == Name);
            return _mapper.Map<RelatedWebsiteDto>(Entity);
        }

        public async Task<RelatedWebsiteDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.RelatedWebsite.Get(x => x.NameEn == Name);
            return _mapper.Map<RelatedWebsiteDto>(Entity);
        }
    }
}
