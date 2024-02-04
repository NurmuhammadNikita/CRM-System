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
    public class GetByIdStudentCommandHandler : IRequestHandler<GetByIdStudentCommand, Student>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async public Task<Student> Handle(GetByIdStudentCommand request, CancellationToken cancellationToken)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
