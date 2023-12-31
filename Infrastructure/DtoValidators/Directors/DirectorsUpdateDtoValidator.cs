﻿
using FluentValidation;
using Infrastructure.Dtos.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.Directors
{
    internal class DirectorsUpdateDtoValidator : AbstractValidator<DirectorsUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly IDirectorsService _DirectorsService;

        public DirectorsUpdateDtoValidator(IFileService FileService, IDirectorsService DirectorsService) 
        {
            _FileService = FileService;
            _DirectorsService = DirectorsService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");

            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameAr, cancellation) => {
                    return await DirectorsArNameExits(NameAr, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name Required").MustAsync(
                async (model, NameEn, cancellation) => {
                    return await DirectorsEnNameExits(NameEn, model.Id, cancellation);
                }).WithMessage("NameAr Is Exits");

        }

        public async Task<bool> DirectorsArNameExits(string NameAr, string Id, CancellationToken arg2) 
        {
            var Galry = await _DirectorsService.GetByArName(NameAr);
            if(Galry.Id != Id)
                return false;
            return Galry is null;
        }

        public async Task<bool> DirectorsEnNameExits(string Name, string Id, CancellationToken arg2)
        {
            var Galry = await _DirectorsService.GetByEnName(Name);
            if (Galry.Id != Id)
                return false;
            return Galry is null;
        }

    }
}
