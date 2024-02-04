using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Application.UseCases.VideoCase.Commands
{
    public class CreateVideoCommand : IRequest
    {
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string VIdeoDate { get; set; }
    }
}
