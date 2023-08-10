
using FluentValidation;
using Infrastructure.Dtos.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.News
{
    internal class NewsUpdateDtoValidator : AbstractValidator<NewsUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly INewsService _NewsService;

        public NewsUpdateDtoValidator(IFileService FileService, INewsService NewsService) 
        {
            _FileService = FileService;
            _NewsService = NewsService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.TitleAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await NewsArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await NewsEnNameExits(NameEn, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Invalid File Type");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            if (File is null)
                return true;
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> NewsArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _NewsService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> NewsEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _NewsService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
