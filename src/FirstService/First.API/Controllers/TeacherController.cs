
using First.API.DTOs;
using First.Application.UseCases.TeacherCase.Commands;
using First.Application.UseCases.TeacherCase.Queries;
using First.Application.UseCases.TeacherCase.Commands;
using First.Application.UseCases.TeacherCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async ValueTask<IActionResult> CreateTeacherAsync(TeacherDTO teacherDTO)
        {
            var command = new CreateTeacherCommand()
            {
                FirstName = teacherDTO.FirstName,
                LastName = teacherDTO.LastName,
                MiddleName = teacherDTO.MiddleName,
                Email = teacherDTO.Email,
                Password = teacherDTO.Password,
                PhoneNumber = teacherDTO.PhoneNumber,
            };
            await _mediator.Send(command);
            return Ok("Created");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllTeacherAsync()
        {
            return Ok(await _mediator.Send(new GetAllTeacherCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdTeacher(int Id)
        {

            var teacher = await _mediator.Send(new GetByIdTeacherCommand() { Id = Id });

            return Ok(teacher);
        }


        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeacher(int Id, [FromForm] TeacherDTO teacherDTO)
        {
            var command = new UpdateTeacherCommand()
            {
                Id = Id,
                FirstName = teacherDTO.FirstName,
                LastName = teacherDTO.LastName,
                MiddleName = teacherDTO.MiddleName,
                Email = teacherDTO.Email,
                Password = teacherDTO.Password,
                PhoneNumber = teacherDTO.PhoneNumber,

            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTeacher(int Id)
        {
            var command = new DeleteTeacherCommand()
            {
                Id = Id
            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
