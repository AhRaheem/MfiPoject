

using Infrastructure.Dtos.Directors;

namespace Infrastructure.Services
{
	public class DirectorsService : IDirectorsService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public DirectorsService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(DirectorsCreateDto Dto)
		{
			await _unitOfWork.Directors.Add(_mapper.Map<Directors>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.Directors.GetById(Id);
			if (Entity is null)
				return false;
			await _unitOfWork.Directors.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<DirectorsDto>> GetAll(string q = "", int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.Directors.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.NameAr.Contains(q) || x.NameEn.Contains(q));
			return await Qry.ProjectTo<DirectorsDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<DirectorsDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.Directors.GetById(Id);
			return _mapper.Map<DirectorsDto>(Entity);
		}

		public async Task<bool> Update(DirectorsUpdateDto Dto)
		{
			var Entity = _mapper.Map<Directors>(Dto);
			await _unitOfWork.Directors.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<DirectorsUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<DirectorsUpdateDto>(await _unitOfWork.Directors.GetById(Id));
        }

        public async Task<DirectorsDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.Directors.Get(x => x.NameAr == Name);
            return _mapper.Map<DirectorsDto>(Entity);
        }

        public async Task<DirectorsDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.Directors.Get(x => x.NameEn == Name);
            return _mapper.Map<DirectorsDto>(Entity);
        }
    }
}
