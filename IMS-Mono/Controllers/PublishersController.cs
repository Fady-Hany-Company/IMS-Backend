using IMS.Application.DTOs.PublishersDTO.CreatePublisher;
using IMS.Application.Features.Publishers.CreatePublisher;
using IMS.Application.Features.Publishers.GetPublishers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : BaseController
    {
        public PublishersController(ILogger<BaseController> logger, IMediator mediator) : base(logger, mediator)
        {
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation($"[Controller] Selecting publishers");
                var publishers = await Mediator.Send(new GetPublishersQuery());

                return Ok(new { Publishers = publishers });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> InsertPublisher([FromBody] CreatePublisherRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"[Controller] Creating publisher with name: {requestDto.Name}");
                var publisherId = await Mediator.Send(new CreatePublisherCommand(requestDto));

                return Ok(new { PublisherId = publisherId });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
