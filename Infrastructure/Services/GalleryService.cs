

namespace Infrastructure.Services
{
	public class GalleryService : IGalleryService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public GalleryService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(GalleryCreateDto Dto)
		{
			var Entity = _mapper.Map<Gallery>(Dto);
            Entity.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Gallery.Add(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.Gallery.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.MainFileId);
			await _unitOfWork.Gallery.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<GalleryDto>> GetAll(string? q , int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.Gallery.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			return await Qry.ProjectTo<GalleryDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<PaginatedList<GalleryDto>> GetAllWithItems(string? q, int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.Gallery.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size, include : x=>x.Include(g=>g.Items.Where(i=>!i.IsDeleted)));
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			return await Qry.ProjectTo<GalleryDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<GalleryDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.Gallery.GetById(Id);
			return _mapper.Map<GalleryDto>(Entity);
		}

        public async Task<GalleryDto> GetByIdWithItems(string Id)
        {
            var Entity = await _unitOfWork.Gallery.GetById(Id,include: x=>x.Include(g=>g.Items));
            return _mapper.Map<GalleryDto>(Entity);
        }

        public async Task<bool> Update(GalleryUpdateDto Dto)
		{
			var Entity = _mapper.Map<Gallery>(Dto);
			if (Dto.File != null)
				Entity.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Gallery.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<GalleryUpdateDto> GetUpdateInfo(string Id)
        {
			return _mapper.Map<GalleryUpdateDto>(await _unitOfWork.Gallery.GetById(Id));
        }

        public async Task<bool> CreateGalleryItem(GalleryItemCreateDto Dto)
        {
            Dto.FileId = await _fileService.Create(Dto.File);
            await _unitOfWork.Gallery.CreateGalleryItem(_mapper.Map<GalleryItem>(Dto));
            return (await _unitOfWork.Save()) > 0;
        }

        public async Task<bool> DeleteGalleryItem(string Id)
        {
            var Entity = await _unitOfWork.Gallery.GetItem(Id);
            if (Entity is null)
                return false;
            await _fileService.Delete(Entity.FileId);
            await _unitOfWork.Gallery.DeleteGalleryItem(Entity);
            return (await _unitOfWork.Save()) > 0;
        }

        public Task<bool> SortGalleryItems(List<SortModel> Dtos)
        {
            throw new NotImplementedException();
        }

        public async Task<GalleryDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.Gallery.Get(x=>x.TitleAr == Name);
            return _mapper.Map<GalleryDto>(Entity);
        }

        public async Task<GalleryDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.Gallery.Get(x => x.TitleEn == Name);
            return _mapper.Map<GalleryDto>(Entity);
        }
    }
}
