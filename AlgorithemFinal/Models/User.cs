using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlgorithemFinal.Models
{

    public class User
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Code { get; set; }

        // I have to change this guy
        public int Rule { get; set; }
    }
}
