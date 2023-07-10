

namespace Infrastructure.Services
{
	public class PartnerCategoryService : IPartnerCategoryService
	{
		public IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public PartnerCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<bool> Create(PartnerCategoryCreateDto Dto)
		{
			await _unitOfWork.PartnerCategory.Add(_mapper.Map<PartnerCategory>(Dto));
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.PartnerCategory.GetById(Id);
			if (Entity is null)
				return false;
			await _unitOfWork.PartnerCategory.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<PaginatedList<PartnerCategoryDto>> GetAll(string q = "", int page = 0, int size = 10)
		{
			var Qry = _unitOfWork.PartnerCategory.GetAllQuery(predicate: x => !x.IsDeleted, page: page, size: size);
			if (!string.IsNullOrWhiteSpace(q))
				Qry = Qry.Where(x => x.NameAr.Contains(q) || x.NameEn.Contains(q));
			return await Qry.ProjectTo<PartnerCategoryDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(page, size);
		}

		public async Task<PartnerCategoryDto> GetById(string Id)
		{
			var Entity = await _unitOfWork.PartnerCategory.GetById(Id);
			return _mapper.Map<PartnerCategoryDto>(Entity);
		}

		public async Task<bool> Update(PartnerCategoryUpdateDto Dto)
		{
			var Entity = _mapper.Map<PartnerCategory>(Dto);
			await _unitOfWork.PartnerCategory.Update(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public async Task<IEnumerable<PartnerCategoryDto>> GetList()
		{
            return _mapper.Map<IEnumerable<PartnerCategoryDto>>(await _unitOfWork.PartnerCategory.GetAll(page: 0, size: 1000));
		}

        public async Task<PartnerCategoryDto> GetByArName(string Name)
        {
            var Entity = await _unitOfWork.PartnerCategory.Get(x => x.NameAr == Name);
            return _mapper.Map<PartnerCategoryDto>(Entity);
        }

        public async Task<PartnerCategoryDto> GetByEnName(string Name)
        {
            var Entity = await _unitOfWork.PartnerCategory.Get(x => x.NameEn == Name);
            return _mapper.Map<PartnerCategoryDto>(Entity);
        }
    }
}
