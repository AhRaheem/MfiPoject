using Api.Enums;
using Api.Models;
using AutoMapper;
using FluentValidation;
using Infrastructure.Dtos.AboutUs;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Partner;
using Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsAndAchievementController : ControllerBase
    {
        public readonly INewsService _NewsService;
        public readonly IAchievementService _AchievementService;
        private readonly IMapper _mapper;

        public NewsAndAchievementController(INewsService newsService, IAchievementService achievementService, IMapper Mapper)
        {
            _NewsService = newsService;
            _AchievementService = achievementService;
            _mapper = Mapper;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<NewsAndAchievementModel>> Get(string Id)
        {
            var Data = new NewsAndAchievementModel();
            var News = await _NewsService.GetById(Id);
            if (News is not null)
                return Ok(_mapper.Map<NewsAndAchievementModel>(News));

            var Achievment = await _AchievementService.GetById(Id);
            if (Achievment is not null)
                return Ok(_mapper.Map<NewsAndAchievementModel>(Achievment));
            return NotFound();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<NewsAndAchievementModel>>> GetAll(DateTime? FromDate, DateTime? ToDate, string q="", SortByType SortByTypeFlag = 0,int Page=1,int Size=9)
        {
            var Data = new List<NewsAndAchievementModel>();
            var News = await _NewsService.GetAll(q, FromDate, ToDate, page: Page, size: Size);
            var Achievments = await _AchievementService.GetAll(q,FromDate,ToDate,page: Page, size: Size);
            if (News is not null)
                Data.AddRange(_mapper.Map<List<NewsAndAchievementModel>>(News));
            if (Achievments is not null)
                Data.AddRange(_mapper.Map<List<NewsAndAchievementModel>>(Achievments));
            if(SortByTypeFlag == SortByType.Newest)
                Data = Data.OrderByDescending(x => x.CreatedOn).ToList();
            if (SortByTypeFlag == SortByType.Oldest)
                Data = Data.OrderBy(x => x.CreatedOn).ToList();
            return Ok(Data);
        }
    }
}
