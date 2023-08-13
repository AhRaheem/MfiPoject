

using Infrastructure.Dtos.Achievement;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Protocol;

namespace Infrastructure.Services
{
	public class AchievementService : IAchievementService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public AchievementService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(AchievementCreateDto Dto)
		{
			Dto.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Achievement.Add(_mapper.Map<Achievement>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.Achievement.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.MainFileId);
			await _unitOfWork.Achievement.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<AchievementDto>> GetAll(DateTime? FromDate = null, DateTime? ToDate = null, string q = "", int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.Achievement.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			return await Qry.ProjectTo<AchievementDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

        public async Task<List<AchievementDto>> GetHomeAchievments()
        {
            var Entities = await _unitOfWork.Achievement.GetAll(x => x.HomePost);
            return _mapper.Map<List<AchievementDto>>(Entities);
        }

        public async Task<AchievementDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.Achievement.GetById(Id);
			return _mapper.Map<AchievementDto>(Entity);
		}

		public async Task<bool> Update(AchievementUpdateDto Dto)
		{
			var Entity = _mapper.Map<Achievement>(Dto);
			if (Dto.File != null)
				Entity.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Achievement.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<AchievementUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<AchievementUpdateDto>(await _unitOfWork.Achievement.GetById(Id));
        }

        public async Task<AchievementDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.Achievement.Get(x => x.TitleAr == Name);
            return _mapper.Map<AchievementDto>(Entity);
        }

        public async Task<AchievementDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.Achievement.Get(x => x.TitleEn == Name);
            return _mapper.Map<AchievementDto>(Entity);
        }

        public async Task<List<AchievementDto>> GetTittled()
        {
            var Entities = await _unitOfWork.Achievement.GetAll(x => x.Titled);
            return _mapper.Map<List<AchievementDto>>(Entities);
        }

        public async Task<List<AchievementDto>> GetBannered()
        {
            var Entities = await _unitOfWork.Achievement.GetAll(x => x.Bannerpost);
            return _mapper.Map<List<AchievementDto>>(Entities);
        }
    }
}
