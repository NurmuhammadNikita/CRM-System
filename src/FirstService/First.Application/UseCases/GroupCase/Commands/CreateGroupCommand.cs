using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.GroupCase.Commands
{
    public class CreateGroupCommand : IRequest
    {
        public int GroupNumber { get; set; }
        public int FacultyId { get; set; }
        public int TeacherId { get; set; }
        public int StudentNumber { get; set; }
        public int OpeningDate { get; set; }
    }
}
