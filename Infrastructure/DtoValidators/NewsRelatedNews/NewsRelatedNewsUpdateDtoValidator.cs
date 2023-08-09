
using FluentValidation;
using Infrastructure.Dtos.NewsRelatedNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.NewsRelatedNews
{
    internal class NewsRelatedNewsUpdateDtoValidator : AbstractValidator<NewsRelatedNewsUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly INewsRelatedNewsService _NewsRelatedNewsService;

        public NewsRelatedNewsUpdateDtoValidator(IFileService FileService, INewsRelatedNewsService NewsRelatedNewsService) 
        {
            _FileService = FileService;
            _NewsRelatedNewsService = NewsRelatedNewsService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await NewsRelatedNewsArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await NewsRelatedNewsEnNameExits(NameEn, model.Id, cancellation);
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

        public async Task<bool> NewsRelatedNewsArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _NewsRelatedNewsService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> NewsRelatedNewsEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _NewsRelatedNewsService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
