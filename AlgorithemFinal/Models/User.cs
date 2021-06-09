using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public int Rule { get; set; }

        public int? MasterId { get; set; }

        public Master Master { get; set; }

        public int? AdminId { get; set; }

        public Admin Admin { get; set; }

        public int? StudentId { get; set; }

        public Student Student { get; set; }
    }
}
