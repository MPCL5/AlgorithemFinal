using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class AnnouncementRequest
    {
        [Required]
        public int TimeTableId { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
