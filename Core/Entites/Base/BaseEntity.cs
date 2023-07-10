using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? CreatedById { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string? UpdatedById { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
        public string? DeletedById { get; set; }

    }
}
