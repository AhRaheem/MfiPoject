
using FluentValidation;
using Infrastructure.Dtos.PostArticleParagraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.PostArticleParagraph
{
    internal class PostArticleParagraphCreateDtoValidator : AbstractValidator<PostArticleParagraphCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IPostArticleParagraphService _PostArticleParagraphService;

        public PostArticleParagraphCreateDtoValidator(IFileService FileService, IPostArticleParagraphService PostArticleParagraphService) 
        {
            _FileService = FileService;
            _PostArticleParagraphService = PostArticleParagraphService;
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }
    }
}
