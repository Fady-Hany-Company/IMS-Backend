using AutoMapper;
using IMS.Application.DTOs.CategoriesDTO.CreateCategory;
using IMS.Application.DTOs.CategoriesDTO.GetCategories;
using IMS.Application.Features.Categories.CreateCategory;
using IMS.Application.Features.Categories.GetCategories;
using IMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(ILogger<BaseController> logger, IMediator mediator, IMapper mapper) : base(logger, mediator, mapper)
        {
        }

        [HttpGet("")]
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

        [HttpPost("")]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryRequestDto requestDto)
        {
            try
            {
                _logger.LogInformation($"[Controller] Creating category with name: {requestDto.CategoryName}");
                var categoryId = await Mediator.Send(new AddCategoryCommand(requestDto));

                return Ok(new { CategoryId = categoryId });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
