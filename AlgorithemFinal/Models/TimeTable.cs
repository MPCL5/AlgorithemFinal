using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class TimeTable
    {
        public int Id { get; set; }
        public User Master { get; set; }
        public List<TimeTableBell> TimeTableBells { get; set; }
    }
}
