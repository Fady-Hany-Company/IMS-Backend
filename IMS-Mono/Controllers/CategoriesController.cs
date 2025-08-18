using IMS.Application.DTOs.Categories.CreateCategory;
using IMS.Application.Features.Categories.CreateCategory;
using IMS.Application.Features.Categories.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(ILogger<BaseController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"[Controller] Creating category with name: {requestDto.CategoryName}");
                var categoryId = await Mediator.Send(new CreateCategoryCommand(requestDto));

                return Ok(new { CategoryId = categoryId });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                _logger.LogInformation($"[Controller] Get Categories");
                var categories = await Mediator.Send(new GetCategoriesQuery());

                return Ok(categories);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
