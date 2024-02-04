using First.Application.Abstractions;
using First.Application.UseCases.GroupCase.Commands;
using First.Domain.Tables.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.GroupCase.Handlers
{
    public class CreateGroupCommandHandler : AsyncRequestHandler<CreateGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            Group group = new Group()
            { 
                GroupNumber = request.GroupNumber,
                FacultyId = request.FacultyId,
                TeacherId = request.TeacherId,
                StudentNumber = request.StudentNumber,
                OpeningDate = request.OpeningDate,
            };

            Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(x => x.Id == request.FacultyId);
            group.Faculty = faculty;


            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }
    }
}
