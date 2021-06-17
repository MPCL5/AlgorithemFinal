using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Response
{
    public class TimeTableDeatilsResponse
    {
        public int Id { get; set; }

        //[Required]
        //public int MasterId { get; set; }

        //[Required]
        public Master Master { get; set; }

        public ICollection<TimeTableBell> TimeTableBells { get; set; }

        //[Required]
        //public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
