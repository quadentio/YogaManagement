using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class BaseEntity : Entity
    {

    }

    public class Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public interface ISoftDeleteEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}
