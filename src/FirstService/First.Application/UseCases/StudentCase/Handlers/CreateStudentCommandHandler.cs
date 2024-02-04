using First.Application.Abstractions;
using First.Application.UseCases.StudentCase.Commands;
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
    public class CreateStudentCommandHandler : AsyncRequestHandler<CreateStudentCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student()
            { 
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                
            };

            Group group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.GroupId);
            student.Groups.Add(group);



            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
