using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public TimeTable TimeTable { get; set; }
        public string Message { get; set; }
    }
}
