
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Paragraph
{
    //internal class ParagraphUpdateDtoValidator : AbstractValidator<PostParagraphUpdateDto>
    //{
    //    public readonly IFileService _FileService;
    //    public readonly IPostService _PostService;

    //    public ParagraphUpdateDtoValidator(IFileService FileService, IPostService PostService) 
    //    {
    //        _FileService = FileService;
    //        _PostService = PostService;
    //        RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

    //        RuleFor(x => x.TitleAr).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleAr, cancellation) => {
    //                return await ParagraphArNameExits(TitleAr, model.Id, cancellation);
    //            }).WithMessage("NameAr Is Exits");

    //        RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleEn, cancellation) => {
    //                return await ParagraphEnNameExits(TitleEn, model.Id, cancellation);
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

    //    public async Task<bool> ParagraphArNameExits(string TitleAr, string Id, CancellationToken arg2) 
    //    {
    //        var Galry = await _PostService.GetParagraphByArName(TitleAr);
    //        if(Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //    public async Task<bool> ParagraphEnNameExits(string Title, string Id, CancellationToken arg2)
    //    {
    //        var Galry = await _PostService.GetParagraphByEnName(Title);
    //        if (Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //}
}
