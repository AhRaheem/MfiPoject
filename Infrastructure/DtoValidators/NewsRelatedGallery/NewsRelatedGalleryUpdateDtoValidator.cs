
using FluentValidation;
using Infrastructure.Dtos.NewsRelatedGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.NewsRelatedGallery
{
    internal class NewsRelatedGalleryUpdateDtoValidator : AbstractValidator<NewsRelatedGalleryUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly INewsRelatedGalleryService _NewsRelatedGalleryService;

        public NewsRelatedGalleryUpdateDtoValidator(IFileService FileService, INewsRelatedGalleryService NewsRelatedGalleryService) 
        {
            _FileService = FileService;
            _NewsRelatedGalleryService = NewsRelatedGalleryService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await NewsRelatedGalleryArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await NewsRelatedGalleryEnNameExits(NameEn, model.Id, cancellation);
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

        public async Task<bool> NewsRelatedGalleryArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _NewsRelatedGalleryService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> NewsRelatedGalleryEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _NewsRelatedGalleryService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
