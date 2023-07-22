namespace Core.Entites.Base
{
    public abstract class Post : Postbase
    {
        public PostState PostState { get; set; }

        public string? RejectReason { get; set; }

        public bool HomePost { get; set; }
        public bool Bannerpost { get; set; }
    }
}
