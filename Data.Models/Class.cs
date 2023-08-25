﻿using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Class : BaseEntity
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassType { get; set; }
        public string MonthPeriod { get; set; }
    }
}
