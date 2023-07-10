
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.RelatedWebsite
{
    internal class RelatedWebsiteUpdateDtoValidator : AbstractValidator<RelatedWebsiteUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IRelatedWebsiteService _RelatedWebsiteService;

        public RelatedWebsiteUpdateDtoValidator(IFileService FileService, IRelatedWebsiteService RelatedWebsiteService) 
        {
            _FileService = FileService;
            _RelatedWebsiteService = RelatedWebsiteService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await RelatedWebsiteArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await RelatedWebsiteEnNameExits(NameEn, model.Id, cancellation);
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

        public async Task<bool> RelatedWebsiteArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _RelatedWebsiteService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> RelatedWebsiteEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _RelatedWebsiteService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
