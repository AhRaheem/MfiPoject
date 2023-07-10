
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.RelatedWebsite
{
    internal class RelatedWebsiteCreateDtoValidator : AbstractValidator<RelatedWebsiteCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IRelatedWebsiteService _RelatedWebsiteService;

        public RelatedWebsiteCreateDtoValidator(IFileService FileService, IRelatedWebsiteService RelatedWebsiteService) 
        {
            _FileService = FileService;
            _RelatedWebsiteService = RelatedWebsiteService;
            RuleFor(x => x.NameAr).NotNull().WithMessage("Name Required").MustAsync(RelatedWebsiteArNameExits).WithMessage("Name Exits");
            RuleFor(x => x.NameEn).NotNull().WithMessage("Name Required").MustAsync(RelatedWebsiteEnNameExits).WithMessage("Name Exits");
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> RelatedWebsiteArNameExits(string NameAr, CancellationToken arg2)
        {
            var Galry = await _RelatedWebsiteService.GetByArName(NameAr);
            return Galry is null;
        }

        public async Task<bool> RelatedWebsiteEnNameExits(string Name, CancellationToken arg2)
        {
            var Galry = await _RelatedWebsiteService.GetByEnName(Name);
            return Galry is null;
        }
    }
}
