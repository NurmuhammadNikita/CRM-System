using First.Application.Abstractions;
using First.Application.UseCases.FacultyCase.Commands;
using First.Domain.Tables.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.FacultyCase.Handlers
{
    internal class CreateFacultyCommandHandler : AsyncRequestHandler<CreateFacultyCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateFacultyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
        {
            Faculty faculty = new Faculty()
            {
                CourseName = request.CourseName,
                Continuity = request.Continuity,
                Price = request.Price,
            };

            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
        }
    }
}
