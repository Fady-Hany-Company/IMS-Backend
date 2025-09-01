using AutoMapper;
using IMS.Application.DTOs.GenresDTO.CreateGenre;
using IMS.Application.Features.Genres.CreateGenre;
using IMS.Application.Features.Genres.GetGenres;
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
        
        [HttpGet("")]
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                _logger.LogInformation($"[Controller] Get genres");
                var genres = await Mediator.Send(new GetGenresQuery());

                return Ok(new { Genres = genres });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddGenre([FromBody] AddGenreRequestDto genreDto)
        {
            try
            {
                _logger.LogInformation($"[Controller] Creating genre with name: {genreDto.Name}");
                var genreId = await Mediator.Send(new AddGenreCommand(genreDto));

                return Ok(new { GenreId = genreId });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
