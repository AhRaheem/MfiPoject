
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Post
{
    //internal class PostUpdateDtoValidator : AbstractValidator<PostUpdateDto>
    //{
    //    public readonly IFileService _FileService;
    //    public readonly IPostService _PostService;

    //    public PostUpdateDtoValidator(IFileService FileService, IPostService PostService) 
    //    {
    //        _FileService = FileService;
    //        _PostService = PostService;
    //        RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

    //        RuleFor(x => x.TitleAr).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleAr, cancellation) => {
    //                return await PostArNameExits(TitleAr, model.Id, cancellation);
    //            }).WithMessage("NameAr Is Exits");

    //        RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleEn, cancellation) => {
    //                return await PostEnNameExits(TitleEn, model.Id, cancellation);
    //            }).WithMessage("NameAr Is Exits");

    //        RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Invalid File Type");

    //        RuleFor(x => x.BreakingFrom).Must((model, ToDate) => { return BreakingDatesValid(model.BreakingFrom.Value, ToDate.Value); }).WithMessage("Breaking Dates Not Valid");
    //    }

    //    public bool ValidImageOrVideoFile(IFormFile File) 
    //    {
    //        if (File is null)
    //            return true;
    //        var Extention = Path.GetExtension(File.FileName).Replace(".","");
    //        return _FileService.IsImage(Extention);
    //    }

    //    public async Task<bool> PostArNameExits(string TitleAr, string Id, CancellationToken arg2) 
    //    {
    //        var Galry = await _PostService.GetByArName(TitleAr);
    //        if(Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //    public async Task<bool> PostEnNameExits(string Title, string Id, CancellationToken arg2)
    //    {
    //        var Galry = await _PostService.GetByEnName(Title);
    //        if (Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //    public bool BreakingDatesValid(DateTime From, DateTime To) 
    //    {
    //        if(From == To)
    //            return true;
    //        if (From >= DateTime.Now && To > From)
    //            return true;
    //        return false;
    //    }

    //}
}
