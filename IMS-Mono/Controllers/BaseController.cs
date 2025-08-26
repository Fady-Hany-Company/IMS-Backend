using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        private IMediator _mediator;
        public BaseController(ILogger<BaseController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IActionResult HandleException(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the request.");
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
        }

    }
}
