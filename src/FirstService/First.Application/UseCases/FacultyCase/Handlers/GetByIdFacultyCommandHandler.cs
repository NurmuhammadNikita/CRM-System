using First.Application.Abstractions;
using First.Application.UseCases.FacultyCase.Queries;
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
    public class GetByIdFacultyCommandHandler : IRequestHandler<GetByIdFacultyCommand, Faculty>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdFacultyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async Task<Faculty> IRequestHandler<GetByIdFacultyCommand, Faculty>.Handle(GetByIdFacultyCommand request, CancellationToken cancellationToken)
        {
            return await _context.Faculties.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
