using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class TimeTableBell
    {
        public int Id { get; set; }
        public Day Day { get; set; }
        public Bell Bell { get; set; }
        public TimeTable TimeTable { get; set; }
    }
}
