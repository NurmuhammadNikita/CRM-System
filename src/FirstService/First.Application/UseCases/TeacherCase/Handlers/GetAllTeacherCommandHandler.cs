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
    public class GetAllTeacherCommandHandler : IRequestHandler<GetAllTeacherCommand, List<Teacher>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> Handle(GetAllTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _context.Teachers.ToListAsync();
        }
    }
}
