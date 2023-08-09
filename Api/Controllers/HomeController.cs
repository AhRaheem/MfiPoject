using Api.Helpers;
using Api.Models;
using AutoMapper;
using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IAboutUsService _AboutUsService;
        public readonly IServiceService _ServiceService;
        public readonly INewsService _NewsService;
        public readonly IProtocolService _ProtocolService;
        public readonly IAchievementService _AchievementService;
        public readonly IGalleryService _GalleryService;
        public readonly IRelatedWebsiteService _RelatedWebsiteService;
        public readonly IPartnerService _PartnerService;
        private readonly IMapper _mapper;
        public HomeController(IAboutUsService AboutUsService)
        {
            _AboutUsService = AboutUsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Lang = Request.GetLanguage();

            var AboutUsInfo = (await _AboutUsService.GetUpdateInfo());

            var TittledServices = await _ServiceService.GetTittled();
            var TittledNews = await _NewsService.GetTittled();
            var TittledAchievments = await _AchievementService.GetTittled();
            var TittledProtocols = await _ProtocolService.GetTittled();

            var BanneredServices = await _ServiceService.GetBannered();
            var BanneredNews = await _NewsService.GetBannered();
            var BanneredAchievments = await _AchievementService.GetBannered();
            var BanneredProtocols = await _ProtocolService.GetBannered();

            var ServicesInfo = (await _ServiceService.GetAll(size: 6)).Items;
            var GalleriesInfo = (await _GalleryService.GetAll(size: 10)).Items;
            var PartnersInfo = (await _PartnerService.GetAll(size: 6)).Items;
            var RelatedWebsitesInfo = (await _RelatedWebsiteService.GetAll(size: 6)).Items;

            var Data = new MainPageModel();

            Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledServices));
            Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledNews));
            Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledAchievments));
            Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledProtocols));

            Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredServices));
            Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredNews));
            Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredAchievments));
            Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredProtocols));

            Data.Services = _mapper.Map<List<HomePostModel>>(ServicesInfo);
            Data.Galleries = GalleriesInfo;
            Data.Partners = PartnersInfo;
            Data.RelatedWebsites = RelatedWebsitesInfo;
            Data.AboutsUsIntro = Lang == "ar" ? AboutUsInfo.IntroAr : AboutUsInfo.IntroEn;
            return Ok(Data);
        }
    }
}
//https://code-maze.com/aspnetcore-in-memory-caching/