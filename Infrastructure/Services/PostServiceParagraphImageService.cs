

using Infrastructure.Dtos.PostServiceParagraphImage;

namespace Infrastructure.Services
{
	public class PostServiceParagraphImageService : IPostServiceParagraphImageService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public PostServiceParagraphImageService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(PostServiceParagraphImageCreateDto Dto)
		{
			await _unitOfWork.PostServiceParagraphImage.Add(_mapper.Map<PostServiceParagraphImage>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.PostServiceParagraphImage.GetById(Id);
			if (Entity is null)
				return false;
			await _unitOfWork.PostServiceParagraphImage.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<PostServiceParagraphImageDto>> GetAll(string q = "", int page = 0, int size = 10)
		{
			var Qry = _unitOfWork.PostServiceParagraphImage.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
		
			return await Qry.ProjectTo<PostServiceParagraphImageDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<PostServiceParagraphImageDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.PostServiceParagraphImage.GetById(Id);
			return _mapper.Map<PostServiceParagraphImageDto>(Entity);
		}

		public async Task<bool> Update(PostServiceParagraphImageUpdateDto Dto)
		{
			var Entity = _mapper.Map<PostServiceParagraphImage>(Dto);
			await _unitOfWork.PostServiceParagraphImage.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<PostServiceParagraphImageUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<PostServiceParagraphImageUpdateDto>(await _unitOfWork.PostServiceParagraphImage.GetById(Id));
        }
    }
}
