
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Gallery
{
    internal class GalleryItemCreateDtoValidator : AbstractValidator<GalleryItemCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IGalleryService _GalleryService;

        public GalleryItemCreateDtoValidator(IFileService FileService, IGalleryService GalleryService) 
        {
            _FileService = FileService;
            _GalleryService = GalleryService;
            RuleFor(x => x.GalleryId).NotNull().MustAsync(GalleryExits).WithMessage("Gallery Not Exits");
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Invalid File Type");
        }

        public async Task<bool> GalleryExits(string GalleryId, CancellationToken arg2) 
        {
            var Glry = await _GalleryService.GetById(GalleryId);
            return Glry != null;
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsVideo(Extention) || _FileService.IsImage(Extention);
        }
    }
}
