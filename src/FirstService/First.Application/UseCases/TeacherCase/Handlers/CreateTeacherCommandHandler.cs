using First.Application.Abstractions;
using First.Application.UseCases.TeacherCase.Commands;
using First.Domain.Tables.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.TeacherCase.Handlers
{
    public class CreateTeacherCommandHandler : AsyncRequestHandler<CreateTeacherCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTeacherCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = new Teacher()
            { 
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
