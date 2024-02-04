using First.API.DTOs;
using First.Application.UseCases.GroupCase.Commands;
using First.Application.UseCases.GroupCase.Queries;
using First.Application.UseCases.StudentCase.Commands;
using First.Application.UseCases.StudentCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async ValueTask<IActionResult> CreateGroupAsync(GroupDTO groupDTO)
        {
            var command = new CreateGroupCommand()
            {
                FacultyId = groupDTO.FacultyId,
                TeacherId = groupDTO.TeacherId,
                GroupNumber = groupDTO.GroupNumber,

            };
            await _mediator.Send(command);
            return Ok("Created");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllGroupAsync()
        {
            return Ok(await _mediator.Send(new GetAllGroupCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdGroup(int Id)
        {

            var group = await _mediator.Send(new GetByIdGroupCommand() { Id = Id });

            return Ok(group);
        }


        [HttpPut]
        public async ValueTask<IActionResult> UpdateGroup(int Id, [FromForm] GroupDTO groupDTO)
        {
            var command = new UpdateGroupCommand()
            {
                Id = Id,
                FacultyId = groupDTO.FacultyId,
                TeacherId = groupDTO.TeacherId,
            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteGroup(int Id)
        {
            var command = new DeleteGroupCommand()
            {
                Id = Id
            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
