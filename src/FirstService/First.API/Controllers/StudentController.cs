using First.API.DTOs;
using First.Application.UseCases.StudentCase.Commands;
using First.Application.UseCases.StudentCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async ValueTask<IActionResult> CreateStudentAsync(StudentDTO studentDTO)
        {
            var command = new CreateStudentCommand()
            {
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                MiddleName = studentDTO.MiddleName,
                Email = studentDTO.Email,
                Password = studentDTO.Password,
                PhoneNumber = studentDTO.PhoneNumber,
            };
            await _mediator.Send(command);
            return Ok("Created");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllStudentAsync()
        {
            return Ok(await _mediator.Send(new GetAllUserCommand()));
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdStudent(int Id)
        {

            var student = await _mediator.Send(new GetByIdStudentCommand() { Id = Id });

            return Ok(student);
        }


        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudent(int Id, [FromForm] StudentDTO studentDTO)
        {
            var command = new UpdateStudentCommand()
            {
                Id = Id,
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                MiddleName = studentDTO.MiddleName,
                Email = studentDTO.Email,
                Password= studentDTO.Password,
                PhoneNumber = studentDTO.PhoneNumber,
               
            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudent(int Id)
        {
            var command = new DeleteStudentCommand()
            {
                Id = Id
            };

            bool result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

