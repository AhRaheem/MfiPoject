﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.News
{
    public class NewsDto : IMapFrom<Core.Entites.News>
    {
        public string? Id { get; set; }
        public string? MainFileId { get; set; }
        public string? TitleAr { get; set; }
        public string? TitleEn { get; set; }

        public string? IntroAr { get; set; }
        public string? IntroEn { get; set; }

        public PostState PostState { get; set; }

        public string? RejectReason { get; set; }

        public bool HomePost { get; set; }
        public bool Bannerpost { get; set; }

        public DateTime? BreakingFrom { get; set; }
        public DateTime? BreakingTo { get; set; }
        public bool Titled { get; set; }

        public virtual ICollection<PostArticleParagraph>? PostArticleParagraphs { get; set; }
        public virtual ICollection<PostAffiliateLaw>? AffiliateLaws { get; set; }

        public virtual ICollection<NewsRelatedNews>? NewsRelatedNews { get; set; }
        public virtual ICollection<NewsRelatedGallery>? NewsRelatedGalleries { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}