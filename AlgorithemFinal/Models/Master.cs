using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class Master
    {
        public int Id { get; set; }

        public User User { get; set; }

        public List<TimeTableBell> TimeTableBells { get; set; }
        public List<TimeTable> TimeTables { get; set; }
    }
}
