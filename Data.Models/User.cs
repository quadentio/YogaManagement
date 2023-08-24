using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class User : Entity, ISoftDeleteEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
