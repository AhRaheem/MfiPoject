
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.PartnerCategory
{
    internal class PartnerCategoryUpdateDtoValidator : AbstractValidator<PartnerCategoryUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IPartnerCategoryService _PartnerCategoryService;

        public PartnerCategoryUpdateDtoValidator(IFileService FileService, IPartnerCategoryService PartnerCategoryService) 
        {
            _FileService = FileService;
            _PartnerCategoryService = PartnerCategoryService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await PartnerCategoryArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await PartnerCategoryEnNameExits(NameEn, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            if (File is null)
                return true;
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsVideo(Extention) || _FileService.IsImage(Extention);
        }

        public async Task<bool> PartnerCategoryArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _PartnerCategoryService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> PartnerCategoryEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _PartnerCategoryService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
