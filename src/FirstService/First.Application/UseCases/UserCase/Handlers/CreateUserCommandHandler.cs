using First.Application.Abstractions;
using First.Application.UseCases.UserCase.Commands;
using First.Domain.Tables.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.UserCase.Handlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
