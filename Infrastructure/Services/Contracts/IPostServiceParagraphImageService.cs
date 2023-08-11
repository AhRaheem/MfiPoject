

using Infrastructure.Dtos.PostServiceParagraphImage;

namespace Infrastructure.Services.Contracts
{
	public interface IPostServiceParagraphImageService
    {
		Task<bool> Create(PostServiceParagraphImageCreateDto Dto);

		Task<bool> Update(PostServiceParagraphImageUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<PostServiceParagraphImageDto>> GetAll(string q= "", int page = 1, int size = 10);

		Task<PostServiceParagraphImageDto> GetById(string Id);

        Task<PostServiceParagraphImageUpdateDto> GetUpdateInfo(string Id);

    }
}
