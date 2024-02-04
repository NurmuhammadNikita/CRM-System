using First.Application.Abstractions;
using First.Application.UseCases.TeacherCase.Queries;
using First.Domain.Tables.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.TeacherCase.Handlers
{
    public class GetByIdTeacherCommandHandler : IRequestHandler<GetByIdTeacherCommand, Teacher>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> Handle(GetByIdTeacherCommand request, CancellationToken cancellationToken)
        {
           Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (teacher == null)
            {
                return new Teacher();
            }
            return teacher;
        }
    }
}
