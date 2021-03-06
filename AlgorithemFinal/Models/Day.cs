using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class Day
    {
        public int Id { get; set; }

        [Required]
        public string Label { get; set; }

        public int DayOfWeek { get; set; }
    }
}
