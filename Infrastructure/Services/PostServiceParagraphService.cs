

using Infrastructure.Dtos.PostServiceParagraph;

namespace Infrastructure.Services
{
	public class PostServiceParagraphService : IPostServiceParagraphService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public PostServiceParagraphService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(PostServiceParagraphCreateDto Dto)
		{
			await _unitOfWork.PostServiceParagraph.Add(_mapper.Map<PostServiceParagraph>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.PostServiceParagraph.GetById(Id);
			if (Entity is null)
				return false;
			await _unitOfWork.PostServiceParagraph.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<PostServiceParagraphDto>> GetAll(string q = "", int page = 0, int size = 10)
		{
			var Qry = _unitOfWork.PostServiceParagraph.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			return await Qry.ProjectTo<PostServiceParagraphDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<PostServiceParagraphDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.PostServiceParagraph.GetById(Id);
			return _mapper.Map<PostServiceParagraphDto>(Entity);
		}

		public async Task<bool> Update(PostServiceParagraphUpdateDto Dto)
		{
			var Entity = _mapper.Map<PostServiceParagraph>(Dto);
			await _unitOfWork.PostServiceParagraph.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<PostServiceParagraphUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<PostServiceParagraphUpdateDto>(await _unitOfWork.PostServiceParagraph.GetById(Id));
        }

        public async Task<PostServiceParagraphDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.PostServiceParagraph.Get(x => x.TitleAr == Name);
            return _mapper.Map<PostServiceParagraphDto>(Entity);
        }

        public async Task<PostServiceParagraphDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.PostServiceParagraph.Get(x => x.TitleEn == Name);
            return _mapper.Map<PostServiceParagraphDto>(Entity);
        }
    }
}
