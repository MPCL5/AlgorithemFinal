using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        public string Code { get; set; }

        [NotMapped]
        public string Rule {
            get
            {
                if (this.Master != null)
                    return nameof(Master).ToLower();
                else if (this.Admin != null)
                    return nameof(Admin).ToLower();
                else if (this.Student != null)
                    return nameof(Student).ToLower();
                else
                    return "unknown";
            }
        }

        [JsonIgnore]
        public int? MasterId { get; set; }

        [JsonIgnore]
        public Master Master { get; set; }

        [JsonIgnore]
        public int? AdminId { get; set; }

        [JsonIgnore]
        public Admin Admin { get; set; }

        [JsonIgnore]
        public int? StudentId { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }
    }
}
