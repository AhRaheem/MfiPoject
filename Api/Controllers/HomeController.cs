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
        public HomeController(IAboutUsService AboutUsService, 
                              IServiceService ServiceService, 
                              INewsService NewsService, 
                              IProtocolService ProtocolService, 
                              IAchievementService AchievementService, 
                              IGalleryService GalleryService, 
                              IRelatedWebsiteService RelatedWebsiteService, 
                              IPartnerService PartnerService)
        {
            _AboutUsService = AboutUsService;
            _ServiceService = ServiceService;
            _NewsService = NewsService;
            _ProtocolService = ProtocolService;
            _AchievementService = AchievementService;
            _GalleryService = GalleryService;
            _RelatedWebsiteService = RelatedWebsiteService;
            _PartnerService = PartnerService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<MainPageModel>> Get()
        {
            var Lang = Request.GetLanguage();

            //var AboutUsInfo = (await _AboutUsService.GetUpdateInfo());

            //var TittledServices = await _ServiceService.GetTittled();
            //var TittledNews = await _NewsService.GetTittled();
            //var TittledAchievments = await _AchievementService.GetTittled();
            //var TittledProtocols = await _ProtocolService.GetTittled();

            //var BanneredServices = await _ServiceService.GetBannered();
            //var BanneredNews = await _NewsService.GetBannered();
            //var BanneredAchievments = await _AchievementService.GetBannered();
            //var BanneredProtocols = await _ProtocolService.GetBannered();

            //var ServicesInfo = (await _ServiceService.GetAll(page: 1, size: 6)).Items;
            //var GalleriesInfo = (await _GalleryService.GetAll(page: 1,size: 10)).Items;
            //var PartnersInfo = (await _PartnerService.GetAll(page: 1, size: 6)).Items;
            //var RelatedWebsitesInfo = (await _RelatedWebsiteService.GetAll(page: 1, size: 6)).Items;

            var Data = new MainPageModel();

            //if (TittledServices.Count > 0)
            //    Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledServices));
            //if (TittledNews.Count > 0)
            //    Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledNews));
            //if (TittledAchievments.Count > 0)
            //    Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledAchievments));
            //if (TittledProtocols.Count > 0)
            //    Data.TittledPosts.AddRange(_mapper.Map<List<TittledModel>>(TittledProtocols));
            //if (BanneredServices.Count > 0)
            //    Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredServices));
            //if (BanneredNews.Count > 0)
            //    Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredNews));
            //if (BanneredAchievments.Count > 0)
            //    Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredAchievments));
            //if (ServicesInfo.Count > 0)
            //    Data.BanneredPosts.AddRange(_mapper.Map<List<BanneredModel>>(BanneredProtocols));
            //if (ServicesInfo.Count > 0)
            //    Data.Services = _mapper.Map<List<HomePostModel>>(ServicesInfo);
            //Data.Galleries = GalleriesInfo;
            //Data.Partners = PartnersInfo;
            //Data.RelatedWebsites = RelatedWebsitesInfo;
            //if(AboutUsInfo is not null)
            //    Data.AboutsUsIntro = Lang == "ar" ? AboutUsInfo.IntroAr : AboutUsInfo.IntroEn;
            return Ok(Data);
        }
    }
}
//https://code-maze.com/aspnetcore-in-memory-caching/