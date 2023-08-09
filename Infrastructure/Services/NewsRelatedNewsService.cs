

using Infrastructure.Dtos.NewsRelatedNews;

namespace Infrastructure.Services
{
	public class NewsRelatedNewsService : INewsRelatedNewsService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public NewsRelatedNewsService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(NewsRelatedNewsCreateDto Dto)
		{
			Dto.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.NewsRelatedNews.Add(_mapper.Map<NewsRelatedNews>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.NewsRelatedNews.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.FileId);
			await _unitOfWork.NewsRelatedNews.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<NewsRelatedNewsDto>> GetAll(string q = "", int page = 0, int size = 10)
		{
			var Qry = _unitOfWork.NewsRelatedNews.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.ar.Contains(q) || x.NameEn.Contains(q));
			return await Qry.ProjectTo<NewsRelatedNewsDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<NewsRelatedNewsDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.NewsRelatedNews.GetById(Id);
			return _mapper.Map<NewsRelatedNewsDto>(Entity);
		}

		public async Task<bool> Update(NewsRelatedNewsUpdateDto Dto)
		{
			var Entity = _mapper.Map<NewsRelatedNews>(Dto);
			if (Dto.File != null)
				Entity.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.NewsRelatedNews.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<NewsRelatedNewsUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<NewsRelatedNewsUpdateDto>(await _unitOfWork.NewsRelatedNews.GetById(Id));
        }

        public async Task<NewsRelatedNewsDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.NewsRelatedNews.Get(x => x.NameAr == Name);
            return _mapper.Map<NewsRelatedNewsDto>(Entity);
        }

        public async Task<NewsRelatedNewsDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.NewsRelatedNews.Get(x => x.NameEn == Name);
            return _mapper.Map<NewsRelatedNewsDto>(Entity);
        }
    }
}
