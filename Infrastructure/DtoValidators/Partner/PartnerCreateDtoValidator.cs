
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Partner
{
    internal class PartnerCreateDtoValidator : AbstractValidator<PartnerCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IPartnerService _PartnerService;

        public PartnerCreateDtoValidator(IFileService FileService, IPartnerService PartnerService) 
        {
            _FileService = FileService;
            _PartnerService = PartnerService;
            RuleFor(x => x.NameAr).NotNull().WithMessage("Name Required").MustAsync(PartnerArNameExits).WithMessage("Name Exits");
            RuleFor(x => x.NameEn).NotNull().WithMessage("Name Required").MustAsync(PartnerEnNameExits).WithMessage("Name Exits");
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> PartnerArNameExits(string NameAr, CancellationToken arg2)
        {
            var Galry = await _PartnerService.GetByArName(NameAr);
            return Galry is null;
        }

        public async Task<bool> PartnerEnNameExits(string Name, CancellationToken arg2)
        {
            var Galry = await _PartnerService.GetByEnName(Name);
            return Galry is null;
        }
    }
}
