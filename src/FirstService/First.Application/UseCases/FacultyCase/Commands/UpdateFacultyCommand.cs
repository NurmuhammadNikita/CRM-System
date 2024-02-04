using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.FacultyCase.Commands
{
    public class UpdateFacultyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Continuity { get; set; }
        public int Price { get; set; }
    }
}
