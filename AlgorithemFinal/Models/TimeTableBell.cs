using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class TimeTableBell
    {
        public int Id { get; set; }

        //public int DayId { get; set; }
        [Required]
        public Day Day { get; set; }

        //[Required]
        //public int BellId { get; set; }

        [Required]
        public Bell Bell { get; set; }

        //public int? TimeTableId { get; set; }
        public TimeTable TimeTable { get; set; }
    }
}
