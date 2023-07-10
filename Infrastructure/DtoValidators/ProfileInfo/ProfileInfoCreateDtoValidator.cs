
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.ProfileInfo
{
    internal class ProfileInfoCreateDtoValidator : AbstractValidator<ProfileInfoCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IProfileInfoService _ProfileInfoService;

        public ProfileInfoCreateDtoValidator(IFileService FileService, IProfileInfoService ProfileInfoService) 
        {
            _FileService = FileService;
            _ProfileInfoService = ProfileInfoService;
            RuleFor(x => x.Name).NotNull().WithMessage("Name Required").MustAsync(ProfileInfoNameExits).WithMessage("Name Exits");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> ProfileInfoNameExits(string NameAr, CancellationToken arg2)
        {
            var Galry = await _ProfileInfoService.GetByName(NameAr);
            return Galry is null;
        }
    }
}
