using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class AuthRequest
    {
        public string Code { get; set; }

        public string Password { get; set; }
    }
}
