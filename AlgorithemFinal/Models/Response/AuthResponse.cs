using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models.Response
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public DateTime ExpireAt { get; set; }

        public User User { get; set; }
    }
}
