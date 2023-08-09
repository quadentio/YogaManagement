using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Class : BaseEntity
    {
        [Key]
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public DaysInWeek ClassType { get; set; }
        public string MonthPeriod { get; set; }
    }

    public enum DaysInWeek
    {
        Five,
        Three,
        Mix
    }
}
