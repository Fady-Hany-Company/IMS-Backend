using AutoMapper;
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
        public PublishersController(ILogger<BaseController> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
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
        public async Task<IActionResult> InsertPublisher([FromBody] AddPublisherRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"[Controller] Creating publisher with name: {requestDto.Name}");
                var publisherId = await Mediator.Send(new AddPublisherCommand(requestDto));

                return Ok(new { PublisherId = publisherId });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
