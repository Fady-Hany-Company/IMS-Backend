using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : BaseController
    {
        public GenresController(ILogger<BaseController> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
        {
        }

    }
}
