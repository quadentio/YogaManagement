namespace Data.Models
{
    public class User : Entity, ISoftDeleteEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
