﻿using Api.Helpers;
using AutoMapper;
using Core.Contracts.Mappings;
using Core.Entites;
using Infrastructure.Dtos.Achievement;
using Infrastructure.Dtos.News;
using Infrastructure.Dtos.Protocol;
using Infrastructure.Dtos.Service;

namespace Api.Models
{
    public class TittledModel : IMapFrom<AchievementDto>, IMapFrom<NewsDto>, IMapFrom<ServiceDto>, IMapFrom<ProtocolDto>
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }

        public void Mapping(Profile profile)
        {
            var IsArabic = Infrastructure.Helpers.HttpcontextHelper.GetHttpcontext().HttpContext.Request.GetLanguage() == "ar";
            profile.CreateMap<AchievementDto, TittledModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => IsArabic ? s.TitleAr : s.TitleEn))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => $"/Achievement/{s.Id}"))
                ;

            profile.CreateMap<NewsDto, TittledModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => IsArabic ? s.TitleAr : s.TitleEn))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => $"/News/{s.Id}"))
                ;

            profile.CreateMap<ServiceDto, TittledModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => IsArabic ? s.TitleAr : s.TitleEn))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => $"/Service/{s.Id}"))
                ;

            profile.CreateMap<ProtocolDto, TittledModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => IsArabic ? s.TitleAr : s.TitleEn))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => $"/Protocol/{s.Id}"))
                ;
        }
    }
}
