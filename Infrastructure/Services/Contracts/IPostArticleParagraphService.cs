

using Infrastructure.Dtos.PostArticleParagraph;

namespace Infrastructure.Services.Contracts
{
	public interface IPostArticleParagraphService
	{
		Task<bool> Create(PostArticleParagraphCreateDto Dto);

		Task<bool> Update(PostArticleParagraphUpdateDto Dto);

		Task<bool> Delete(string Id);

		Task<PaginatedList<PostArticleParagraphDto>> GetAll(string q= "", int page = 1, int size = 10);

		Task<PostArticleParagraphDto> GetById(string Id);
        Task<PostArticleParagraphDto> GetByArName(string Name);
        Task<PostArticleParagraphDto> GetByEnName(string Name);

        Task<PostArticleParagraphUpdateDto> GetUpdateInfo(string Id);

    }
}
