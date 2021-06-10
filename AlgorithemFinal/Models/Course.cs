using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int UnitsCount { get; set; }

        [JsonIgnore]
        public ICollection<TimeTable> TimeTables { get; set; }

        [JsonIgnore]
        public ICollection<Master> Masters { get; set; }
    }
}
