
using FluentValidation;
using Infrastructure.Dtos.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.News
{
    internal class NewsCreateDtoValidator : AbstractValidator<NewsCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly INewsService _NewsService;

        public NewsCreateDtoValidator(IFileService FileService, INewsService NewsService) 
        {
            _FileService = FileService;
            _NewsService = NewsService;
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }
    }
}
