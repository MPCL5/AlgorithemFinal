using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlgorithemFinal.Models.Requests
{
    public class DayRequest
    {
       // [Required]
        public string Label { get; set; }

        // TODO: Override default validator and make this guys not nullable.
        public int? DayOfWeek { get; set; }
    }
}
