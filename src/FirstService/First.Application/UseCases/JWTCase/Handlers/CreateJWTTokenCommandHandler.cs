using First.Application.UseCases.JWTCase.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace First.Application.UseCases.JWTCase.Handlers
{
    internal class CreateJWTTokenCommandHandler : IRequestHandler<CreateJWTTokenCommand, Token>
    {
        private readonly IConfiguration _configuration;

        public CreateJWTTokenCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        async public Task<Token> Handle(CreateJWTTokenCommand request, CancellationToken cancellationToken)
        {
            var user = request.User;

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var bytes = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var key = new SymmetricSecurityKey(bytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            SecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials
                );

            var Token = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token()
            {
                RefundableToken = Token,
                ExpireDate = DateTime.Now.AddDays(1)
            };
        }
    }
}
