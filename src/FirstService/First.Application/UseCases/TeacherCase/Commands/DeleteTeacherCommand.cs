using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.TeacherCase.Commands
{
    public class DeleteTeacherCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
