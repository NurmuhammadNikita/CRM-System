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
    public class GetByIdUserCommandHandler : IRequestHandler<GetByIdUserCommand, User>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync( x => x.Id == request.Id);
        }
    }
}
