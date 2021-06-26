using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class BellRequest
    {
        //[Required]
        public string Label { get; set; }

        // TODO: Override default validator and make this guys not nullable.
        public int? BellOfDay { get; set; }
    }
}
