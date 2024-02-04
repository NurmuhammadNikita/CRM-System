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
    public class GetAllGroupCommandHandler : IRequestHandler<GetAllGroupCommand, List<Group>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async public Task<List<Group>> Handle(GetAllGroupCommand request, CancellationToken cancellationToken)
        {
            return await _context.Groups.ToListAsync();
        }
    }
}
