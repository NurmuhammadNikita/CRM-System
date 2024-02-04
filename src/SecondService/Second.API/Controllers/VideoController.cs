using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Second.API.DTOs;
using Second.Application.Services.VideoServices;
using Second.Application.UseCases.VideoCase.Commands;

namespace Second.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediatr;

        [HttpPost]
        [Route("UploadFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async ValueTask<IActionResult> UploadFile(IFormFile file,CancellationToken cancellationToken)
        {
            /*var command = new CreateVideoCommand()
            {
                Name = videoDTO.Name,
                GroupId = videoDTO.GroupId,
                VIdeoDate = videoDTO.VIdeoDate,
            };

            var result1 = await _mediatr.Send(command);*/

            var result = await UploadVideo.WriteFile(file);

            return Ok(result);

        }

        [HttpGet]
        [Route("DownloadFile")]
        public async ValueTask<IActionResult> DownloadFile(string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filename, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contentType, Path.GetFileName(filepath));
        }
    }
}
