using Infrastructure.Dtos.AboutUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.AboutUs
{
    public class AboutUsUpdateDtoValidator : AbstractValidator<AboutUsUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IAboutUsService _AboutUsService;

        public AboutUsUpdateDtoValidator(IFileService FileService, IAboutUsService AboutUsService)
        {
            _FileService = FileService;
            _AboutUsService = AboutUsService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

        }

        public bool ValidImageOrVideoFile(IFormFile File)
        {
            if (File is null)
                return true;
            var Extention = Path.GetExtension(File.FileName).Replace(".", "");
            return _FileService.IsImage(Extention);
        }

    }
}
