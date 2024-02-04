using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.FacultyCase.Commands
{
    public class DeleteFacultyCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
