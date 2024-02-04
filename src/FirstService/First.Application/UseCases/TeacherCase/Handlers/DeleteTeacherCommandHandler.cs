using First.Application.Abstractions;
using First.Application.UseCases.TeacherCase.Commands;
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
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id);
            

            if (teacher == null)
            {
                return false;
            }
            else
            {
                 _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }

        
    }
}
