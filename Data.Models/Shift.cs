using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Shift : BaseEntity
    {
        [Key]
        public Guid ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int ShiftHour { get; set; }
    }
}
