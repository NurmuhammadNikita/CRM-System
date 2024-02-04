using First.API.DTOs;
using First.Application.UseCases.FacultyCase.Commands;
using First.Application.UseCases.FacultyCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacultyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async ValueTask<IActionResult> CreateFacultyAsync(FacultyDTO facultyDTO)
        {
            var command = new CreateFacultyCommand()
            {
             Continuity = facultyDTO.Continuity,
             CourseName = facultyDTO.CourseName,
             Price = facultyDTO.Price,
            };
            await _mediator.Send(command);
            return Ok("Created");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllFacultyAsync()
        {
            return Ok(await _mediator.Send(new GetAllFacultiesCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdFaculty(int Id)
        {

            var Faculty = await _mediator.Send(new GetByIdFacultyCommand() { Id = Id });

            return Ok(Faculty);
        }


        [HttpPut]
        public async ValueTask<IActionResult> UpdateFaculty(int Id, [FromForm] FacultyDTO FacultyDTO)
        {
            var command = new UpdateFacultyCommand()
            {
                Id = Id,
                

            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteFaculty(int Id)
        {
            var command = new DeleteFacultyCommand()
            {
                Id = Id
            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
