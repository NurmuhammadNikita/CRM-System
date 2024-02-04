using First.Domain.Tables.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.JWTCase.Commands
{
    public class CreateJWTTokenCommand : IRequest<Token> 
    {
        public User User { get; set; }
    }
}
