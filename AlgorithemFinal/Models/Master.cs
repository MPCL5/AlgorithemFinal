using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class Master
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        [JsonIgnore]
        public List<TimeTableBell> TimeTableBells { get; set; }

        [JsonIgnore]
        public List<TimeTable> TimeTables { get; set; }

        [JsonIgnore]
        public List<Course> Courses { get; set; }
    }
}
