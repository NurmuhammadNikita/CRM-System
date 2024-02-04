using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace First.Domain.Tables.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int GroupNumber { get; set; }
        public int FacultyId { get; set; }
        public int TeacherId { get; set; }
        public int StudentNumber { get; set; }
        public int OpeningDate { get; set; }

        public Faculty Faculty { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; }

    }
}
