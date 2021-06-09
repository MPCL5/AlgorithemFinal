using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{
    public class Student
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<TimeTable> TimeTables { get; set; }
    }
}
