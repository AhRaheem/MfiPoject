
using FluentValidation;
using Infrastructure.Dtos.PostArticleParagraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.PostArticleParagraph
{
    internal class PostArticleParagraphUpdateDtoValidator : AbstractValidator<PostArticleParagraphUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IPostArticleParagraphService _PostArticleParagraphService;

        public PostArticleParagraphUpdateDtoValidator(IFileService FileService, IPostArticleParagraphService PostArticleParagraphService) 
        {
            _FileService = FileService;
            _PostArticleParagraphService = PostArticleParagraphService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            if (File is null)
                return true;
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

    }
}
