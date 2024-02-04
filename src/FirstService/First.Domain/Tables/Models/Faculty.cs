using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace First.Domain.Tables.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Continuity { get; set; }
        public int Price { get; set; }
        [JsonIgnore]
        public ICollection<Group> Groups { get; set; }
    }
}
