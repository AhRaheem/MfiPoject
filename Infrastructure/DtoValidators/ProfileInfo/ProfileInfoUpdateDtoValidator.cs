
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.ProfileInfo
{
    internal class ProfileInfoUpdateDtoValidator : AbstractValidator<ProfileInfoUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IProfileInfoService _ProfileInfoService;

        public ProfileInfoUpdateDtoValidator(IFileService FileService, IProfileInfoService ProfileInfoService) 
        {
            _FileService = FileService;
            _ProfileInfoService = ProfileInfoService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, Name, cancellation) => {
                    return await ProfileInfoNameExits(Name, model.Id, cancellation);
                }).WithMessage("Name Is Exits");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            if (File is null)
                return true;
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> ProfileInfoNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _ProfileInfoService.GetByName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
