using AutoMapper;
using IMS.Application.DTOs.AuthorsDTO.CreateAuthor;
using IMS.Application.Features.Authors.CreateAuthor;
using IMS.Application.Features.Authors.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        public AuthorsController(ILogger<BaseController> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                _logger.LogInformation($"[Controller] Starting GetAuthors");
                var authors = await Mediator.Send(new GetAuthorsQuery());

                _logger.LogInformation($"[Controller] Successfully GetAuthors");
                return Ok(new { Authors = authors });

            }
            catch (Exception e)
            {
                throw;
            }
        }
        
        [HttpPost("")]
        public async Task<IActionResult> AddAuthor(AddAuthorRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"[Controller] Starting AddAuthor");
                var authorsId = await Mediator.Send(new AddAuthorCommand(requestDto));

                _logger.LogInformation($"[Controller] Successfully AddAuthor");
                return Ok(new { AuthorId = authorsId });

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
