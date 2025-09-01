using AutoMapper;
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
        private IMapper _mapper;
        public BaseController(ILogger<BaseController> logger,IMediator mediator,IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

    }
}
