
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.AffiliateLaw
{
    internal class AffiliateLawCreateDtoValidator : AbstractValidator<PostAffiliateLawCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IPostService _PostService;

        public AffiliateLawCreateDtoValidator(IFileService FileService, IPostService PostService) 
        {
            _FileService = FileService;
            _PostService = PostService;
            RuleFor(x => x.NameAr).NotNull().WithMessage("Title Required").MustAsync(AffiliateLawArNameExits).WithMessage("Title Exits");
            RuleFor(x => x.NameEn).NotNull().WithMessage("Title Required").MustAsync(AffiliateLawEnNameExits).WithMessage("Title Exits");
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> AffiliateLawArNameExits(string TitleAr, CancellationToken arg2)
        {
            var Galry = await _PostService.GetAffiliateLawByArName(TitleAr);
            return Galry is null;
        }

        public async Task<bool> AffiliateLawEnNameExits(string Title, CancellationToken arg2)
        {
            var Galry = await _PostService.GetAffiliateLawByEnName(Title);
            return Galry is null;
        }
    }
}
