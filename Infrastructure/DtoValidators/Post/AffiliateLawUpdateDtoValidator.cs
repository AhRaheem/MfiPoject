
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.AffiliateLaw
{
    //internal class AffiliateLawUpdateDtoValidator : AbstractValidator<PostAffiliateLawUpdateDto>
    //{
    //    public readonly IFileService _FileService;
    //    public readonly IPostService _PostService;

    //    public AffiliateLawUpdateDtoValidator(IFileService FileService, IPostService PostService) 
    //    {
    //        _FileService = FileService;
    //        _PostService = PostService;
    //        RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

    //        RuleFor(x => x.NameAr).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleAr, cancellation) => {
    //                return await AffiliateLawArNameExits(TitleAr, model.Id, cancellation);
    //            }).WithMessage("NameAr Is Exits");

    //        RuleFor(x => x.NameEn).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleEn, cancellation) => {
    //                return await AffiliateLawEnNameExits(TitleEn, model.Id, cancellation);
    //            }).WithMessage("NameAr Is Exits");

    //        RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Invalid File Type");
    //    }

    //    public bool ValidImageOrVideoFile(IFormFile File) 
    //    {
    //        if (File is null)
    //            return true;
    //        var Extention = Path.GetExtension(File.FileName).Replace(".","");
    //        return _FileService.IsImage(Extention);
    //    }

    //    public async Task<bool> AffiliateLawArNameExits(string TitleAr, string Id, CancellationToken arg2) 
    //    {
    //        var Galry = await _PostService.GetAffiliateLawByArName(TitleAr);
    //        if(Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //    public async Task<bool> AffiliateLawEnNameExits(string Title, string Id, CancellationToken arg2)
    //    {
    //        var Galry = await _PostService.GetAffiliateLawByEnName(Title);
    //        if (Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //}
}
