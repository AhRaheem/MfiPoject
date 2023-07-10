
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Gallery
{
    internal class GalleryCreateDtoValidator : AbstractValidator<GalleryCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IGalleryService _GalleryService;

        public GalleryCreateDtoValidator(IFileService FileService, IGalleryService GalleryService) 
        {
            _FileService = FileService;
            _GalleryService = GalleryService;

            RuleFor(x => x.TitleAr).NotNull().WithMessage("Name Required").MustAsync(GalleryArNameExits).WithMessage("Name Exits");
            RuleFor(x => x.TitleEn).NotNull().WithMessage("Name Required").MustAsync(GalleryEnNameExits).WithMessage("Name Exits");

            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("File Not Valid");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return (_FileService.IsVideo(Extention) || _FileService.IsImage(Extention));
        }

        public async Task<bool> GalleryArNameExits(string TitleAr, CancellationToken arg2)
        {
            var Galry = await _GalleryService.GetByArName(TitleAr);
            return Galry is null;
        }

        public async Task<bool> GalleryEnNameExits(string Title, CancellationToken arg2)
        {
            var Galry = await _GalleryService.GetByEnName(Title);
            return Galry is null;
        }
    }
}
