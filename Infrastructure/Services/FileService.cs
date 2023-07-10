
using ImageMagick;

namespace Infrastructure.Services
{
	public class FileService : IFileService
    {
		public IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public FileService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork= unitOfWork;
			_mapper=mapper;
		}

        public async Task<FileDto> GetById(string Id)
        {
            var Entity = await _unitOfWork.File.GetById(Id);
            return _mapper.Map<FileDto>(Entity);
        }

		public async Task<byte[]> GetImage(FileDto ImgDto,int Width=0, int Height=0) 
		{
			if(Width == 0 && Height == 0)
				return Convert.FromBase64String(ImgDto.Content);
			using (var imageMagick = new MagickImage(Convert.FromBase64String(ImgDto.Content)))
			{
				imageMagick.Resize(Width, Height);
				return imageMagick.ToByteArray();
			}
        }

        public async Task<string> Create(IFormFile filee)
		{
			var Dto = await CreateDto(filee);
			await _unitOfWork.File.Add(_mapper.Map<Core.Entites.File>(Dto));
			await _unitOfWork.Save();
			return Dto.Id;
		}

		public async Task<List<string>> Create(List<IFormFile> filees)
		{
			var Ids = new List<string>();
			foreach (var filee in filees)
			{
				var Dto = await CreateDto(filee);
				await _unitOfWork.File.Add(_mapper.Map<Core.Entites.File>(Dto));
				Ids.Add(Dto.Id);
			}
			await _unitOfWork.Save();
			return Ids;
		}

		public async Task<FileDto> CreateDto(IFormFile filee)
		{
			var Dto = new FileDto();
            Dto.Id = Guid.NewGuid().ToString();
            Dto.Name = filee.FileName;
			Dto.Extention = Path.GetExtension(filee.FileName);
			using (var ms = new MemoryStream())
			{
				await filee.CopyToAsync(ms);
				var fileBytes = ms.ToArray();
				Dto.Content = Convert.ToBase64String(fileBytes);
			}
			return Dto;
		}

		public async Task<bool> Delete(string Id)
		{
			var Entity = await _unitOfWork.File.GetById(Id);
			if (Entity is null)
				return false;
			await _unitOfWork.File.Delete(Entity);
			return (await _unitOfWork.Save()) > 0;
		}

		public bool IsImage(string Extention)
		{
			string[] ImgExtentions = { "jpg", "jpeg", "png" };
			return ImgExtentions.Contains(Extention);
        }

        public bool IsVideo(string Extention)
        {
            string[] VideoExtentions = { "mp4", "avi" };
            return VideoExtentions.Contains(Extention);
        }

        public bool IsDocument(string Extention)
        {
            string[] DocsExtentions = { "pdf", "text", "docx" };
            return DocsExtentions.Contains(Extention);
        }
    }
}
