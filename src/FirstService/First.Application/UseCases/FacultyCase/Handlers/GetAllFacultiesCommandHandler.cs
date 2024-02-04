using First.Application.Abstractions;
using First.Application.UseCases.FacultyCase.Queries;
using First.Domain.Tables.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.FacultyCase.Handlers
{
    public class GetAllFacultiesCommandHandler : IRequestHandler<GetAllFacultiesCommand, List<Faculty>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllFacultiesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Faculty>> Handle(GetAllFacultiesCommand request, CancellationToken cancellationToken)
        {
            
               return await _context.Faculties.ToListAsync();

            
        }
    }
}
