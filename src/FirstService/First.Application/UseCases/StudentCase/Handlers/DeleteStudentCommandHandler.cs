using First.Application.Abstractions;
using First.Application.UseCases.StudentCase.Commands;
using First.Domain.Tables.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.StudentCase.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = await _context.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (student == null)
            {
                return false;
            }
            else
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
