

using Infrastructure.Dtos.PostServiceParagraph;
using Infrastructure.Dtos.PostServiceParagraph;

namespace Infrastructure.Services.Contracts
{
	public interface IPostServiceParagraphService
    {
		Task<bool> Create(PostServiceParagraphCreateDto Dto);

		Task<bool> Update(PostServiceParagraphUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<PostServiceParagraphDto>> GetAll(string q= "", int page = 1, int size = 10);

		Task<PostServiceParagraphDto> GetById(string Id);
        Task<PostServiceParagraphDto> GetByArName(string Name);
        Task<PostServiceParagraphDto> GetByEnName(string Name);

        Task<PostServiceParagraphUpdateDto> GetUpdateInfo(string Id);

    }
}
