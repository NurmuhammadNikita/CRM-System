using First.Application.Abstractions;
using First.Application.UseCases.GroupCase.Queries;
using First.Application.UseCases.StudentCase.Queries;
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
    public class GetByIdGroupCommandHandler : IRequestHandler<GetByIdGroupCommand, Group>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async public Task<Group> Handle(GetByIdGroupCommand request, CancellationToken cancellationToken)
        {
            return await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}

