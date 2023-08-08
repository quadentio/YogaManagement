using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Shift
    {
        [Key]
        public Guid ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int ShiftHour { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }

    }
}
