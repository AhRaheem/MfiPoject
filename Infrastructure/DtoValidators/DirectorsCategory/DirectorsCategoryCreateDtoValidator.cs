
using FluentValidation;
using Infrastructure.Dtos.DirectorsCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.DirectorsCategory
{
    internal class DirectorsCategoryCreateDtoValidator : AbstractValidator<DirectorsCategoryCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IDirectorsCategoryService _DirectorsCategoryService;

        public DirectorsCategoryCreateDtoValidator(IFileService FileService, IDirectorsCategoryService DirectorsCategoryService) 
        {
            _FileService = FileService;
            _DirectorsCategoryService = DirectorsCategoryService;
            RuleFor(x => x.NameAr).NotNull().WithMessage("Name Required").MustAsync(DirectorsCategoryArNameExits).WithMessage("Name Exits");
            RuleFor(x => x.NameEn).NotNull().WithMessage("Name Required").MustAsync(DirectorsCategoryEnNameExits).WithMessage("Name Exits");
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> DirectorsCategoryArNameExits(string NameAr, CancellationToken arg2)
        {
            var Galry = await _DirectorsCategoryService.GetByArName(NameAr);
            return Galry is null;
        }

        public async Task<bool> DirectorsCategoryEnNameExits(string Name, CancellationToken arg2)
        {
            var Galry = await _DirectorsCategoryService.GetByEnName(Name);
            return Galry is null;
        }
    }
}
