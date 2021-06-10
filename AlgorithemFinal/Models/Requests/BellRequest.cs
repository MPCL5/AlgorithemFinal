using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class BellRequest
    {
        [Required]
        public string Label { get; set; }

        public int BellOfDay { get; set; }
    }
}
