
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Post
{
    //internal class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
    //{
    //    public readonly IFileService _FileService;
    //    public readonly IPostService _PostService;

    //    public PostCreateDtoValidator(IFileService FileService, IPostService PostService) 
    //    {
    //        _FileService = FileService;
    //        _PostService = PostService;
    //        RuleFor(x => x.TitleAr).NotNull().WithMessage("Title Required").MustAsync(PostArNameExits).WithMessage("Title Exits");
    //        RuleFor(x => x.TitleEn).NotNull().WithMessage("Title Required").MustAsync(PostEnNameExits).WithMessage("Title Exits");
    //        RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
    //    }

    //    public bool ValidImageOrVideoFile(IFormFile File)
    //    {
    //        var Extention = Path.GetExtension(File.FileName).Replace(".","");
    //        return _FileService.IsImage(Extention);
    //    }

    //    public async Task<bool> PostArNameExits(string TitleAr, CancellationToken arg2)
    //    {
    //        var Galry = await _PostService.GetByArName(TitleAr);
    //        return Galry is null;
    //    }

    //    public async Task<bool> PostEnNameExits(string Title, CancellationToken arg2)
    //    {
    //        var Galry = await _PostService.GetByEnName(Title);
    //        return Galry is null;
    //    }
    //}
}
