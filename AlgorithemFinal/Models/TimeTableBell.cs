using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
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

        //public int CourseId { get; set; }

        //[JsonIgnore]
        //public Course Course { get; set; }

        //public int? TimeTableId { get; set; }

        [JsonIgnore]
        public TimeTable TimeTable { get; set; }

        [NotMapped]
        public bool HaveCourse => TimeTable != null;

        [JsonIgnore]
        public int MasterId { get; set; }
        
        public Master Master { get; set; }
    }
}
