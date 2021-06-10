using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class TimeTableBellRequest
    {
        /// <summary>
        /// id rouz
        /// </summary>
        [Required]
        public int DayId { get; set; }

        /// <summary>
        /// id zang
        /// </summary>
        [Required]
        public int BellId { get; set; }

        ///// <summary>
        ///// id dars
        ///// </summary>
        //[Required]
        //public int CourseId { get; set; }

        public int TimeTableId { get; set; }
    }
}
