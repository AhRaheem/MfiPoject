

using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Protocol;
using Infrastructure.Dtos.Service;

namespace Infrastructure.Services
{
	public class ProtocolService : IProtocolService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IMapper _mapper;

		public ProtocolService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_fileService = fileService;
		}

		public async Task<bool> Create(ProtocolCreateDto Dto)
		{
			Dto.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Protocol.Add(_mapper.Map<Protocol>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.Protocol.GetById(Id);
			if (Entity is null)
				return false;
			await _fileService.Delete(Entity.MainFileId);
			await _unitOfWork.Protocol.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<ProtocolDto>> GetAll(DateTime? FromDate = null, DateTime? ToDate = null, string q = "", int page = 1, int size = 10)
		{
			var Qry = _unitOfWork.Protocol.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.TitleAr.Contains(q) || x.TitleEn.Contains(q));
			if (FromDate.HasValue || FromDate.Value > DateTime.MinValue)
				Qry = Qry.Where(x => x.CreatedOn >= FromDate);
            if (ToDate.HasValue || ToDate.Value > DateTime.MinValue)
                Qry = Qry.Where(x => x.CreatedOn <= ToDate);
            return await Qry.ProjectTo<ProtocolDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

        public async Task<ProtocolDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.Protocol.GetById(Id);
			return _mapper.Map<ProtocolDto>(Entity);
		}

		public async Task<bool> Update(ProtocolUpdateDto Dto)
		{
			var Entity = _mapper.Map<Protocol>(Dto);
			if (Dto.File != null)
				Entity.MainFileId = await _fileService.Create(Dto.File);
			await _unitOfWork.Protocol.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

        public async Task<ProtocolUpdateDto> GetUpdateInfo(string Id)
        {
            return _mapper.Map<ProtocolUpdateDto>(await _unitOfWork.Protocol.GetById(Id));
        }

        public async Task<ProtocolDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.Protocol.Get(x => x.TitleAr == Name);
            return _mapper.Map<ProtocolDto>(Entity);
        }

        public async Task<ProtocolDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.Protocol.Get(x => x.TitleEn == Name);
            return _mapper.Map<ProtocolDto>(Entity);
        }

        public async Task<List<ProtocolDto>> GetTittled()
        {
            var Entities = await _unitOfWork.Protocol.GetAll(x => x.Titled);
            return _mapper.Map<List<ProtocolDto>>(Entities);
        }

        public async Task<List<ProtocolDto>> GetBannered()
        {
            var Entities = await _unitOfWork.Protocol.GetAll(x => x.Bannerpost);
            return _mapper.Map<List<ProtocolDto>>(Entities);
        }
    }
}
