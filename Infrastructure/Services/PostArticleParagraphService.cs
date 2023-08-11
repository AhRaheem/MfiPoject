

using Infrastructure.Dtos.PostArticleParagraph;

namespace Infrastructure.Services
{
	public class PostArticleParagraphService : IPostArticleParagraphService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public PostArticleParagraphService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(PostArticleParagraphCreateDto Dto)
		{
			Dto.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.PostArticleParagraph.Add(_mapper.Map<PostArticleParagraph>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.PostArticleParagraph.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.FileId);
			await _unitOfWork.PostArticleParagraph.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<PostArticleParagraphDto>> GetAll(string q = "", int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.PostArticleParagraph.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			return await Qry.ProjectTo<PostArticleParagraphDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<PostArticleParagraphDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.PostArticleParagraph.GetById(Id);
			return _mapper.Map<PostArticleParagraphDto>(Entity);
		}

		public async Task<bool> Update(PostArticleParagraphUpdateDto Dto)
		{
			var Entity = _mapper.Map<PostArticleParagraph>(Dto);
			if (Dto.FileId != null)
				Entity.FileId = await _fileService.Create(Dto.File);
			await _unitOfWork.PostArticleParagraph.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<PostArticleParagraphUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<PostArticleParagraphUpdateDto>(await _unitOfWork.PostArticleParagraph.GetById(Id));
        }

        public async Task<PostArticleParagraphDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.PostArticleParagraph.Get(x => x.TitleAr == Name);
            return _mapper.Map<PostArticleParagraphDto>(Entity);
        }

        public async Task<PostArticleParagraphDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.PostArticleParagraph.Get(x => x.TitleEn == Name);
            return _mapper.Map<PostArticleParagraphDto>(Entity);
        }
    }
}
