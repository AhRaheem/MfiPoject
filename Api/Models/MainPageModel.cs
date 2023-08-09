using Core.Entites;
using Infrastructure.Dtos.Gallery;
using Infrastructure.Dtos.Partner;
using Infrastructure.Dtos.RelatedWebsite;
using Infrastructure.Dtos.Service;

namespace Api.Models
{
    public class MainPageModel
    {
        public MainPageModel()
        {
            TittledPosts = new List<TittledModel>();
            BanneredPosts = new List<BanneredModel>();
            Services = new List<HomePostModel>();
            Galleries = new List<GalleryDto>();
            Partners= new List<PartnerDto>();
            RelatedWebsites = new List<RelatedWebsiteDto>();
        }
        public List<TittledModel>? TittledPosts { get; set; }
        public List<BanneredModel>? BanneredPosts { get; set; }
        public string? AboutsUsIntro { get; set; }
        public List<HomePostModel> Services { get; set; }
        public List<GalleryDto> Galleries { get; set; }
        public List<PartnerDto> Partners { get; set; }
        public List<RelatedWebsiteDto> RelatedWebsites { get; set; }
    }
}
