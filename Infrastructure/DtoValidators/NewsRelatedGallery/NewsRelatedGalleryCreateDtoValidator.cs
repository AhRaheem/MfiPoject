
using FluentValidation;
using Infrastructure.Dtos.NewsRelatedGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.NewsRelatedGallery
{
    internal class NewsRelatedGalleryCreateDtoValidator : AbstractValidator<NewsRelatedGalleryCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly INewsRelatedGalleryService _NewsRelatedGalleryService;

        public NewsRelatedGalleryCreateDtoValidator(IFileService FileService, INewsRelatedGalleryService NewsRelatedGalleryService) 
        {
            _FileService = FileService;
            _NewsRelatedGalleryService = NewsRelatedGalleryService;
            RuleFor(x => x.NameAr).NotNull().WithMessage("Name Required").MustAsync(NewsRelatedGalleryArNameExits).WithMessage("Name Exits");
            RuleFor(x => x.NameEn).NotNull().WithMessage("Name Required").MustAsync(NewsRelatedGalleryEnNameExits).WithMessage("Name Exits");
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> NewsRelatedGalleryArNameExits(string NameAr, CancellationToken arg2)
        {
            var Galry = await _NewsRelatedGalleryService.GetByArName(NameAr);
            return Galry is null;
        }

        public async Task<bool> NewsRelatedGalleryEnNameExits(string Name, CancellationToken arg2)
        {
            var Galry = await _NewsRelatedGalleryService.GetByEnName(Name);
            return Galry is null;
        }
    }
}
