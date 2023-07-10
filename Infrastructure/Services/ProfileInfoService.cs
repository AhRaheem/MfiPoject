namespace Infrastructure.Services
{
	public class ProfileInfoService : IProfileInfoService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProfileInfoService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<bool> Create(ProfileInfoCreateDto Dto)
		{
			await _unitOfWork.ProfileInfo.Add(_mapper.Map<ProfileInfo>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.ProfileInfo.GetById(Id);
			if (Entity is null)
				return false;
			await _unitOfWork.ProfileInfo.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<IEnumerable<ProfileInfoDto>> GetAll(string? q)
		{
			var Qry = _unitOfWork.ProfileInfo.GetAllQuery(predicate: x => !x.IsDeleted, page:1,size:1000);
			if(!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.IsDeleted);
			var Entities = await Qry.ToListAsync();
            return _mapper.Map<IEnumerable<ProfileInfoDto>>(Entities);
		}

		public async Task<ProfileInfoDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.ProfileInfo.GetById(Id);
			return _mapper.Map<ProfileInfoDto>(Entity);
		}

		public async Task<bool> Update(ProfileInfoUpdateDto Dto)
		{
			var Entity = _mapper.Map<ProfileInfo>(Dto);
			await _unitOfWork.ProfileInfo.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<ProfileInfoUpdateDto> GetUpdateInfo(string Id)
        {
			return _mapper.Map<ProfileInfoUpdateDto>(await _unitOfWork.ProfileInfo.GetById(Id));
        }

        public async Task<ProfileInfoDto> GetByName(string Name)
        {
            var Entity = await _unitOfWork.ProfileInfo.Get(x => x.Name == Name);
            return _mapper.Map<ProfileInfoDto>(Entity);
        }
    }
}
