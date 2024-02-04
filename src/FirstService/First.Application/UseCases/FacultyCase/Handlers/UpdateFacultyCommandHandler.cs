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
    public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateFacultyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
        {
            Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (faculty == null)
            {
                return false;
            }

            faculty.Price = request.Price;
            faculty.CourseName = request.CourseName;
            faculty.Continuity = request.Continuity;

            _context.Faculties.Update(faculty);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
