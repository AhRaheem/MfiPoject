
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.PartnerCategory
{
    internal class PartnerCategoryCreateDtoValidator : AbstractValidator<PartnerCategoryCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IPartnerCategoryService _PartnerCategoryService;

        public PartnerCategoryCreateDtoValidator(IFileService FileService, IPartnerCategoryService PartnerCategoryService) 
        {
            _FileService = FileService;
            _PartnerCategoryService = PartnerCategoryService;
            RuleFor(x => x.NameAr).NotNull().WithMessage("Name Required").MustAsync(PartnerCategoryArNameExits).WithMessage("Name Exits");
            RuleFor(x => x.NameEn).NotNull().WithMessage("Name Required").MustAsync(PartnerCategoryEnNameExits).WithMessage("Name Exits");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsVideo(Extention) || _FileService.IsImage(Extention);
        }

        public async Task<bool> PartnerCategoryArNameExits(string NameAr, CancellationToken arg2)
        {
            var Galry = await _PartnerCategoryService.GetByArName(NameAr);
            return Galry is null;
        }

        public async Task<bool> PartnerCategoryEnNameExits(string Name, CancellationToken arg2)
        {
            var Galry = await _PartnerCategoryService.GetByEnName(Name);
            return Galry is null;
        }
    }
}
