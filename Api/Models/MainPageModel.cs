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
        }
        public List<TittledModel>? TittledPosts { get; set; }
        public List<BanneredModel>? BanneredPosts { get; set; }
    }
}
