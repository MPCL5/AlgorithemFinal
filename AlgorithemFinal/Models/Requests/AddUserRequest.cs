using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Requests
{
    public class AddUserRequest
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }

        public string Code { get; set; }

        public string Role { get; set; }
    }
}
