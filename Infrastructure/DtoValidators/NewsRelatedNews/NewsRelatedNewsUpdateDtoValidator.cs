
using FluentValidation;
using Infrastructure.Dtos.NewsRelatedNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.NewsRelatedNews
{
    internal class NewsRelatedNewsUpdateDtoValidator : AbstractValidator<NewsRelatedNewsUpdateDto>
    {
        public readonly IFileService _FileService;
        public readonly INewsRelatedNewsService _NewsRelatedNewsService;

        public NewsRelatedNewsUpdateDtoValidator(IFileService FileService, INewsRelatedNewsService NewsRelatedNewsService) 
        {
            _FileService = FileService;
            _NewsRelatedNewsService = NewsRelatedNewsService;
            RuleFor(x => x.Id).NotNull().WithMessage("Id Required");


        }


    }
}
