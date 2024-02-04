using First.Application.Abstractions;
using First.Application.UseCases.GroupCase.Commands;
using First.Application.UseCases.StudentCase.Commands;
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
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            Group group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (group == null)
            {
                return false;
            }
            else
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
    }
}
