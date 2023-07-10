
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.User
{
    //internal class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    //{
    //    public readonly IFileService _FileService;
    //    public readonly IUserService _UserService;

    //    public UserUpdateDtoValidator(IFileService FileService, IUserService UserService) 
    //    {
    //        _FileService = FileService;
    //        _UserService = UserService;
    //        RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

    //        RuleFor(x => x.TitleAr).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleAr, cancellation) => {
    //                return await UserArNameExits(TitleAr, model.Id, cancellation);
    //            }).WithMessage("NameAr Is Exits");

    //        RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Title Required").MustAsync(
    //            async (model, TitleEn, cancellation) => {
    //                return await UserEnNameExits(TitleEn, model.Id, cancellation);
    //            }).WithMessage("NameAr Is Exits");

    //        RuleFor(x => x.File).Must(ValidImageOrVideoFile).WithMessage("Invalid File Type");
    //    }

    //    public bool ValidImageOrVideoFile(IFormFile File) 
    //    {
    //        if (File is null)
    //            return true;
    //        var Extention = Path.GetExtension(File.FileName).Replace(".","");
    //        return _FileService.IsVideo(Extention) || _FileService.IsImage(Extention);
    //    }

    //    public async Task<bool> UserArNameExits(string TitleAr, string Id, CancellationToken arg2) 
    //    {
    //        var Galry = await _UserService.GetByArName(TitleAr);
    //        if(Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //    public async Task<bool> UserEnNameExits(string Title, string Id, CancellationToken arg2)
    //    {
    //        var Galry = await _UserService.GetByEnName(Title);
    //        if (Galry.Id != Id)
    //            return false;
    //        return Galry is null;
    //    }

    //}
}
