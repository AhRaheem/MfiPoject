
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Gallery
{
    internal class GalleryUpdateDtoValidator : AbstractValidator<GalleryUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IGalleryService _GalleryService;

        public GalleryUpdateDtoValidator(IFileService FileService, IGalleryService GalleryService) 
        {
            _FileService = FileService;
            _GalleryService = GalleryService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.TitleAr).NotEmpty().WithMessage("Title Required").MustAsync(
                async (model, TitleAr, cancellation) => {
                    return await GalleryArNameExits(TitleAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Title Required").MustAsync(
                async (model, TitleEn, cancellation) => {
                    return await GalleryEnNameExits(TitleEn, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Invalid File Type");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            if (File is null)
                return true;
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsVideo(Extention) || _FileService.IsImage(Extention);
        }

        public async Task<bool> GalleryArNameExits(string TitleAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _GalleryService.GetByArName(TitleAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> GalleryEnNameExits(string Title, string Id, CancellationToken arg2)
        {
            var Galry = await _GalleryService.GetByEnName(Title);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
