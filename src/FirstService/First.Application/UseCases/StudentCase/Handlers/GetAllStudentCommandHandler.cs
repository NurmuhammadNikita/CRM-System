using First.Application.Abstractions;
using First.Application.UseCases.StudentCase.Queries;
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
    internal class GetAllStudentCommandHandler : IRequestHandler<GetAllUserCommand, List<Student>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async public Task<List<Student>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            return await _context.Students.ToListAsync();
        }
    }
}
