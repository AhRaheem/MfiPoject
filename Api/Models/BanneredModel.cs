namespace Api.Models
{
    public class BanneredModel
    {
        public string? Id { get; set; }
        public string? Text { get; set; }
        public string? Link { get; set; }
        public string? Image { get; set; }
        public bool IsBreaking { get; set; }
    }
}
