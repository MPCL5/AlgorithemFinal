using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        [Required]
        public int TimeTableId { get; set; }

        [Required]
        public TimeTable TimeTable { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
