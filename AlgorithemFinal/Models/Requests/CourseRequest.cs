using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class CourseRequest
    {
        [Required]
        public string Title { get; set; }

        public int UnitsCount { get; set; }
    }
}
