using First.Application.Abstractions;
using First.Application.UseCases.TeacherCase.Commands;
using First.Domain.Tables.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.TeacherCase.Handlers
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (teacher == null)
            {
                return false;
            }
            else
            {
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                teacher.MiddleName = request.MiddleName;
                teacher.Email = request.Email;
                teacher.Password = request.Password;
                teacher.PhoneNumber = request.PhoneNumber;

                 _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
