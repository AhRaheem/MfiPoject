
using FluentValidation;
using Infrastructure.Dtos.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Directors
{
    internal class DirectorsCreateDtoValidator : AbstractValidator<DirectorsCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly IDirectorsService _DirectorsService;

        public DirectorsCreateDtoValidator(IFileService FileService, IDirectorsService DirectorsService) 
        {
            _FileService = FileService;
            _DirectorsService = DirectorsService;
            RuleFor(x => x.NameAr).NotNull().WithMessage("Name Required").MustAsync(DirectorsArNameExits).WithMessage("Name Exits");
            RuleFor(x => x.NameEn).NotNull().WithMessage("Name Required").MustAsync(DirectorsEnNameExits).WithMessage("Name Exits");
        }

        public async Task<bool> DirectorsArNameExits(string NameAr, CancellationToken arg2)
        {
            var Galry = await _DirectorsService.GetByArName(NameAr);
            return Galry is null;
        }

        public async Task<bool> DirectorsEnNameExits(string Name, CancellationToken arg2)
        {
            var Galry = await _DirectorsService.GetByEnName(Name);
            return Galry is null;
        }
    }
}
