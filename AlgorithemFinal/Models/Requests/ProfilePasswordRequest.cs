using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class ProfilePasswordRequest
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
