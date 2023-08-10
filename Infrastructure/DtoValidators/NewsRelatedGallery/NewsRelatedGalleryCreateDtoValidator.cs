
using FluentValidation;
using Infrastructure.Dtos.NewsRelatedGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DtoValidators.NewsRelatedGallery
{
    internal class NewsRelatedGalleryCreateDtoValidator : AbstractValidator<NewsRelatedGalleryCreateDto>
    {
        public readonly IFileService _FileService;
        public readonly INewsRelatedGalleryService _NewsRelatedGalleryService;

        public NewsRelatedGalleryCreateDtoValidator(IFileService FileService, INewsRelatedGalleryService NewsRelatedGalleryService) 
        {
            _FileService = FileService;
            _NewsRelatedGalleryService = NewsRelatedGalleryService;
        }
    }
}
