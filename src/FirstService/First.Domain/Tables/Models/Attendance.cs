using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Domain.Tables.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public bool AttendanceResult { get; set; }
        public string AttendanceDate { get; set; }
    }
}
