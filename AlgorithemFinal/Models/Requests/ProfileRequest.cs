using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class ProfileRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}
