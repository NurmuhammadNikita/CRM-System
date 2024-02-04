using First.Domain.Tables.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.TeacherCase.Queries
{
    public class GetByIdTeacherCommand : IRequest<Teacher>
    {
        public int Id { get; set; }
    }
}
