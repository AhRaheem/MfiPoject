

using Infrastructure.Dtos.DirectorsCategory;

namespace Infrastructure.Services
{
	public class DirectorsCategoryService : IDirectorsCategoryService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public DirectorsCategoryService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(DirectorsCategoryCreateDto Dto)
		{
			Dto.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.DirectorsCategory.Add(_mapper.Map<DirectorsCategory>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.DirectorsCategory.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.FileId);
			await _unitOfWork.DirectorsCategory.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<DirectorsCategoryDto>> GetAll(string q = "", int page = 0, int size = 10)
		{
			var Qry = _unitOfWork.DirectorsCategory.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.NameAr.Contains(q) || x.NameEn.Contains(q));
			return await Qry.ProjectTo<DirectorsCategoryDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<DirectorsCategoryDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.DirectorsCategory.GetById(Id);
			return _mapper.Map<DirectorsCategoryDto>(Entity);
		}

		public async Task<bool> Update(DirectorsCategoryUpdateDto Dto)
		{
			var Entity = _mapper.Map<DirectorsCategory>(Dto);
			if (Dto.File != null)
				Entity.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.DirectorsCategory.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<DirectorsCategoryUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<DirectorsCategoryUpdateDto>(await _unitOfWork.DirectorsCategory.GetById(Id));
        }

        public async Task<DirectorsCategoryDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.DirectorsCategory.Get(x => x.NameAr == Name);
            return _mapper.Map<DirectorsCategoryDto>(Entity);
        }

        public async Task<DirectorsCategoryDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.DirectorsCategory.Get(x => x.NameEn == Name);
            return _mapper.Map<DirectorsCategoryDto>(Entity);
        }
    }
}
