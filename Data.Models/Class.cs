using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public DaysInWeek ClassType { get; set; }
        public string MonthPeriod { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }

    public enum DaysInWeek
    {
        Five,
        Three,
        Mix
    }
}
