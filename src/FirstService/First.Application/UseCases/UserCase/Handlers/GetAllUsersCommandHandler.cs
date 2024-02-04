using First.Application.Abstractions;
using First.Application.UseCases.UserCase.Queries;
using First.Domain.Tables.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.UserCase.Handlers
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, List<User>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            return _context.Users.ToListAsync();
        }
    }
}
