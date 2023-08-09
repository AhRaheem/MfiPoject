
using FluentValidation;
using Infrastructure.Dtos.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Service
{
    internal class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IServiceService _ServiceService;

        public ServiceCreateDtoValidator(IFileService FileService, IServiceService ServiceService) 
        {
            _FileService = FileService;
            _ServiceService = ServiceService;
            RuleFor(x => x.File).NotNull().WithMessage("File Required").Must(ValidImageOrVideoFile).WithMessage("Msg");
        }

        public bool ValidImageOrVideoFile(IFormFile File) 
        {
            var Extention = Path.GetExtension(File.FileName).Replace(".","");
            return _FileService.IsImage(Extention);
        }
    }
}
