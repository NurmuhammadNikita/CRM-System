using First.Application.Abstractions;
using First.Application.UseCases.GroupCase.Commands;
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
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            Group group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (group == null)
            {
                return false;
            }
            else
            {
                group.TeacherId = request.TeacherId;
                group.FacultyId = request.FacultyId;
                group.GroupNumber = request.GroupNumber;
                group.StudentNumber = request.StudentNumber;
                group.OpeningDate = request.OpeningDate;

                _context.Groups.Update(group);
               await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
