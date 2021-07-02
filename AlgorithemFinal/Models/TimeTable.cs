using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class TimeTable
    {
        public int Id { get; set; }

        //[Required]
        //public int MasterId { get; set; }

        //[Required]
        public Master Master { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; }

        // [JsonIgnore]
        public ICollection<TimeTableBell> TimeTableBells { get; set; }

        //[Required]
        //public int CourseId { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}
