

using Core.Entites;

namespace Infrastructure.Services
{
	public class PostService : IPostService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public PostService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(PostCreateDto Dto)
		{
			Dto.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Post.Add(_mapper.Map<Post>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.Post.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.MainFileId);
			await _unitOfWork.Post.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<PostDto>> GetAll(PostType PostType, string q = "", int page = 0, int size = 10)
		{
			var Qry = _unitOfWork.Post.GetAllQuery(predicate: x => !x.IsDeleted && x.PostType == PostType, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			return await Qry.ProjectTo<PostDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<PostDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.Post.GetById(Id, enableTracking: false);
			return _mapper.Map<PostDto>(Entity);
		}

        public async Task<PostDto> GetByIdWithParagraphs(string Id)
        {
            var Entity = await _unitOfWork.Post.GetById(Id, include: x => x.Include(g => g.Paragraphs));
            return _mapper.Map<PostDto>(Entity);
        }

        public async Task<PostDto> GetByIdWithAffiliateLaws(string Id)
        {
            var Entity = await _unitOfWork.Post.GetById(Id, include: x => x.Include(g => g.AffiliateLaws));
            return _mapper.Map<PostDto>(Entity);
        }

        public async Task<PostDto> GetDetails(string Id) 
        {
            var Entity = await _unitOfWork.Post.GetById(Id, include: x => x.Include(p => p.AffiliateLaws).Include(p => p.Paragraphs));
            return _mapper.Map<PostDto>(Entity);
        }

        public async Task<bool> Update(PostUpdateDto Dto)
		{
			var Entity = _mapper.Map<Post>(Dto);
			if (Dto.File != null)
				Entity.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Post.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<PostUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<PostUpdateDto>(await _unitOfWork.Post.GetById(Id, include: x => x.Include(p => p.AffiliateLaws).Include(p => p.Paragraphs)));
        }

        public async Task<bool> CreatePostParagraph(PostParagraphCreateDto Dto)
        {
            Dto.FileId = await _fileService.Create(Dto.File);
            await _unitOfWork.Post.CreatePostParagraph(_mapper.Map<PostParagraph>(Dto));
            return (await _unitOfWork.Save()) > 0;
        }

        public async Task<bool> UpdatePostParagraph(PostParagraphUpdateDto Dto)
        {
            var Entity = _mapper.Map<PostParagraph>(Dto);
            if (Dto.File != null)
                Entity.FileId = await _fileService.Create(Dto.File);
            await _unitOfWork.Post.UpdatePostParagraph(Entity);
            return (await _unitOfWork.Save()) > 0;
        }

        public async Task<bool> DeletePostParagraph(string Id)
        {
            var Entity = await _unitOfWork.Post.GetParagraphById(Id);
            if (Entity is null)
                return false;
            await _fileService.Delete(Entity.FileId);
            await _unitOfWork.Post.DeletePostParagraph(Entity);
            return (await _unitOfWork.Save()) > 0;
        }

        public Task<bool> SortPostParagraphs(List<SortModel> Dtos)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostParagraphDto>> GetParagraphs(string PostId)
        {
            return _mapper.Map<IEnumerable<PostParagraphDto>>(await _unitOfWork.Post.GetParagraphs(PostId));
        }

        public async Task<PostParagraphDto> GetParagraph(string Id)
        {
            return _mapper.Map<PostParagraphDto>(await _unitOfWork.Post.GetParagraphById(Id));
        }

        public async Task<PostParagraphUpdateDto> GetParagraphUpdateInfo(string Id)
        {
            return _mapper.Map<PostParagraphUpdateDto>(await _unitOfWork.Post.GetParagraphById(Id));
        }

        public async Task<bool> CreatePostAffiliateLaw(PostAffiliateLawCreateDto Dto)
        {
            Dto.FileId = await _fileService.Create(Dto.File);
            await _unitOfWork.Post.CreatePostAffiliateLaw(_mapper.Map<PostAffiliateLaw>(Dto));
            return (await _unitOfWork.Save()) > 0;
        }

        public async Task<bool> UpdatePostAffiliateLaw(PostAffiliateLawUpdateDto Dto)
        {
            var Entity = _mapper.Map<PostAffiliateLaw>(Dto);
            if (Dto.File != null)
                Entity.FileId = await _fileService.Create(Dto.File);
            await _unitOfWork.Post.UpdatePostAffiliateLaw(Entity);
            return (await _unitOfWork.Save()) > 0;
        }

        public async Task<bool> DeletePostAffiliateLaw(string Id)
        {
            var Entity = await _unitOfWork.Post.GetAffiliateLawById(Id);
            if (Entity is null)
                return false;
            await _fileService.Delete(Entity.FileId);
            await _unitOfWork.Post.DeletePostAffiliateLaw(Entity);
            return (await _unitOfWork.Save()) > 0;
        }

        public Task<bool> SortPostAffiliateLaws(List<SortModel> Dtos)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostAffiliateLawDto>> GetAffiliateLaws(string PostId)
        {
            return _mapper.Map<IEnumerable<PostAffiliateLawDto>>(await _unitOfWork.Post.GetAffiliateLaws(PostId));
        }

        public async Task<PostAffiliateLawDto> GetAffiliateLaw(string Id)
        {
            return _mapper.Map<PostAffiliateLawDto>(await _unitOfWork.Post.GetAffiliateLawById(Id));
        }

        public async Task<PostAffiliateLawUpdateDto> GetAffiliateLawUpdateInfo(string Id)
        {
            return _mapper.Map<PostAffiliateLawUpdateDto>(await _unitOfWork.Post.GetAffiliateLawById(Id));
        }

        public async Task<PostDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.Post.Get(x => x.TitleAr == Name);
            return _mapper.Map<PostDto>(Entity);
        }

        public async Task<PostDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.Post.Get(x => x.TitleEn == Name);
            return _mapper.Map<PostDto>(Entity);
        }

        public async Task<PostParagraphDto> GetParagraphByArName(string Name)
        {
            var Entity = await _unitOfWork.Post.GetParagraphByNameAr(Name);
            return _mapper.Map<PostParagraphDto>(Entity);
        }

        public async Task<PostParagraphDto> GetParagraphByEnName(string Name)
        {
            var Entity = await _unitOfWork.Post.GetAffiliateLawByNameEn(Name);
            return _mapper.Map<PostParagraphDto>(Entity);
        }

        public async Task<PostAffiliateLawDto> GetAffiliateLawByArName(string Name)
        {
            var Entity = await _unitOfWork.Post.GetAffiliateLawByNameAr(Name);
            return _mapper.Map<PostAffiliateLawDto>(Entity);
        }

        public async Task<PostAffiliateLawDto> GetAffiliateLawByEnName(string Name)
        {
            var Entity = await _unitOfWork.Post.GetAffiliateLawByNameEn(Name);
            return _mapper.Map<PostAffiliateLawDto>(Entity);
        }

        public async Task<bool> Publish(string Id)
        {
            var Post = await GetById(Id);
            Post.PostState = PostState.Published;
            var Entity = _mapper.Map<Post>(Post);
            await _unitOfWork.Post.Update(Entity);
            return (await _unitOfWork.Save()) > 0;
        }

        public async Task<bool> Reject(PostRejectDto postRejectDto)
        {
            var Post = await GetById(postRejectDto.Id);
            Post.PostState = PostState.Reject;
            Post.RejectReason = postRejectDto.Reason;
            var Entity = _mapper.Map<Post>(Post);
            await _unitOfWork.Post.Update(Entity);
            return (await _unitOfWork.Save()) > 0;
        }
    }
}
