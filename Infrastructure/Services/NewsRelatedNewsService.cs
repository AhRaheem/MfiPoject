

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
			await _unitOfWork.NewsRelatedNews.Add(_mapper.Map<NewsRelatedNews>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.NewsRelatedNews.GetById(Id);
			if (Entity is null)
				return false;
			await _unitOfWork.NewsRelatedNews.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<NewsRelatedNewsDto>> GetAll(string q = "", int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.NewsRelatedNews.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
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
			await _unitOfWork.NewsRelatedNews.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<NewsRelatedNewsUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<NewsRelatedNewsUpdateDto>(await _unitOfWork.NewsRelatedNews.GetById(Id));
        }
    }
}
