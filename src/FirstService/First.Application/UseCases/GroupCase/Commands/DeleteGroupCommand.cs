using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.GroupCase.Commands
{
    public class DeleteGroupCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
