using First.API.DTOs;
using First.Application.UseCases.StudentCase.Commands;
using First.Application.UseCases.StudentCase.Queries;
using First.Application.UseCases.UserCase.Commands;
using First.Application.UseCases.UserCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async ValueTask<IActionResult> CreateUserAsync(UserDTO userDTO)
        {
            var command = new CreateUserCommand()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                MiddleName = userDTO.MiddleName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                PhoneNumber = userDTO.PhoneNumber,
            };
            await _mediator.Send(command);
            return Ok("Created");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllUserAsync()
        {
            return Ok(await _mediator.Send(new GetAllUserCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdUser(int Id)
        {

            var user = await _mediator.Send(new GetByIdUserCommand() { Id = Id });

            return Ok(user);
        }


        [HttpPut]
        public async ValueTask<IActionResult> UpdateUser(int Id, [FromForm] UserDTO userDTO)
        {
            var command = new UpdateUserCommand()
            {
                Id = Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                MiddleName = userDTO.MiddleName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                PhoneNumber = userDTO.PhoneNumber,

            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUser(int Id)
        {
            var command = new DeleteUserCommand()
            {
                Id = Id
            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
