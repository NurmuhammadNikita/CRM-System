using First.Application.Abstractions;
using First.Application.UseCases.FacultyCase.Commands;
using First.Domain.Tables.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.FacultyCase.Handlers
{
    public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFacultyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
        {
            Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (faculty == null)
            {
                return false;
            }
            
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
