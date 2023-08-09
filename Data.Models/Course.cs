using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Course : BaseEntity, ISoftDeleteEntity
    {
        [Key]
        public Guid CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CoursePrice { get; set; }
        public Guid ClassId { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation Properties
        public Class Class { get; set; }
    }
}
