using MediatR;
using Second.Application.Abstractions;
using Second.Application.UseCases.VideoCase.Commands;
using Second.Domain.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Application.UseCases.VideoCase.Handlers
{
    public class CreateVideoCommandHandler : AsyncRequestHandler<CreateVideoCommand>
    {
        private readonly IApplicationDbContext _context;

        protected override async Task Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            Video video = new Video()
            {
                Name = request.Name,
                GroupId = request.GroupId,
                VIdeoDate = request.VIdeoDate,
            };

            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }
    }
}
