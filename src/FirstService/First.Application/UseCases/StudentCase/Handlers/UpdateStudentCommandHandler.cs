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
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = await _context.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (student == null)
            {
                return false;
            }
            else
            {
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.MiddleName = request.MiddleName;
                student.Email = request.Email;
                student.Password = request.Password;
                student.PhoneNumber = request.PhoneNumber;

                  _context.Students.Update(student);
                await _context.SaveChangesAsync(cancellationToken);
                
                return true;
            }
        }
    }
}
