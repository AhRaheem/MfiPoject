

using Infrastructure.Dtos.Achievement;
using Infrastructure.Dtos.News;

namespace Infrastructure.Services
{
	public class NewsService : INewsService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public NewsService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(NewsCreateDto Dto)
		{
			Dto.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.News.Add(_mapper.Map<News>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.News.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.MainFileId);
			await _unitOfWork.News.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<NewsDto>> GetAll(string q = "", DateTime? FromDate, DateTime? ToDate, int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.News.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
            if (FromDate.HasValue || FromDate.Value > DateTime.MinValue)
                Qry = Qry.Where(x => x.CreatedOn >= FromDate);
            if (ToDate.HasValue || ToDate.Value > DateTime.MinValue)
                Qry = Qry.Where(x => x.CreatedOn <= ToDate);
            return await Qry.ProjectTo<NewsDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<NewsDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.News.GetById(Id);
			return _mapper.Map<NewsDto>(Entity);
		}

		public async Task<bool> Update(NewsUpdateDto Dto)
		{
			var Entity = _mapper.Map<News>(Dto);
			if (Dto.File != null)
				Entity.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.News.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<NewsUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<NewsUpdateDto>(await _unitOfWork.News.GetById(Id));
        }

        public async Task<NewsDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.News.Get(x => x.TitleAr == Name);
            return _mapper.Map<NewsDto>(Entity);
        }

        public async Task<NewsDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.News.Get(x => x.TitleEn == Name);
            return _mapper.Map<NewsDto>(Entity);
        }

        public async Task<List<NewsDto>> GetTittled()
        {
            var Entities = await _unitOfWork.News.GetAll(x => x.Titled);
            return _mapper.Map<List<NewsDto>>(Entities);
        }

        public async Task<List<NewsDto>> GetBannered()
        {
            var Entities = await _unitOfWork.News.GetAll(x => x.Bannerpost);
            return _mapper.Map<List<NewsDto>>(Entities);
        }
    }
}
