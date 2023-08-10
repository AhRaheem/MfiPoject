
using FluentValidation;
using Infrastructure.Dtos.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Service
{
    internal class ServiceUpdateDtoValidator : AbstractValidator<ServiceUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IServiceService _ServiceService;

        public ServiceUpdateDtoValidator(IFileService FileService, IServiceService ServiceService) 
        {
            _FileService = FileService;
            _ServiceService = ServiceService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.TitleAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await ServiceArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.TitleEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await ServiceEnNameExits(NameEn, model.Id, cancellation);
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

        public async Task<bool> ServiceArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _ServiceService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> ServiceEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _ServiceService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
