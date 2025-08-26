using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        public BooksController(ILogger<BaseController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

    }
}
