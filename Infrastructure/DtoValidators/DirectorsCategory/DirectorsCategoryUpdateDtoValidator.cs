
using FluentValidation;
using Infrastructure.Dtos.DirectorsCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.DirectorsCategory
{
    internal class DirectorsCategoryUpdateDtoValidator : AbstractValidator<DirectorsCategoryUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IDirectorsCategoryService _DirectorsCategoryService;

        public DirectorsCategoryUpdateDtoValidator(IFileService FileService, IDirectorsCategoryService DirectorsCategoryService) 
        {
            _FileService = FileService;
            _DirectorsCategoryService = DirectorsCategoryService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await DirectorsCategoryArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await DirectorsCategoryEnNameExits(NameEn, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Invalid File Type");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            if (File is null)
                return true;
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }

        public async Task<bool> DirectorsCategoryArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _DirectorsCategoryService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> DirectorsCategoryEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _DirectorsCategoryService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
