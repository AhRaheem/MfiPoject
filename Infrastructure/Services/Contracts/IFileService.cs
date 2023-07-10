
namespace Infrastructure.Services.Contracts
{
	public interface IFileService
	{
        Task<FileDto> GetById(string Id);
        Task<string> Create(IFormFile filee);
		Task<List<string>> Create(List<IFormFile> filees);
		Task<bool> Delete(string Id);
		Task<FileDto> CreateDto(IFormFile filee);
		Task<byte[]> GetImage(FileDto ImgDto, int Width = 0, int Height = 0);
		bool IsImage(string Extention);
		bool IsVideo(string Extention);
		bool IsDocument(string Extention);
    }
}
