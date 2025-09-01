using AutoMapper;
using IMS.Application.DTOs.BooksDTO.CreateBook;
using IMS.Application.DTOs.BooksDTO.GetBook;
using IMS.Application.Features.Books.CreateBook;
using IMS.Application.Features.Books.GetBook;
using IMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_Mono.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        public BooksController(ILogger<BaseController> logger, IMediator mediator, IMapper mapper) : base(logger,
            mediator, mapper)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetBook(int bookId)
        {
            try
            {
                _logger.LogInformation($"[Controller] Get Books");
                var book = await Mediator.Send(new GetBookQuery(bookId));
                var bookDto = Mapper.Map<GetBookResponseDto>(book);
                return Ok(new { Book = bookDto });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequestDto dto)
        {
            try
            {
                _logger.LogInformation($"[Controller] Get Books");
                var book = Mapper.Map<Books>(dto);
                var bookId = await Mediator.Send(new AddBookCommand(new AddBookRequestDto
                {
                    Name = book.Name,
                    Description = book.Description,
                    CoverImage = book.CoverImage,
                    Pages = book.Pages,
                    PublicationYear = book.PublicationYear,
                    Price = book.Price,
                    GenreId = book.GenreId,
                    PublisherId = book.PublisherId,
                    AuthorId = book.AuthorId,
                    CategoryId = book.CategoryId,
                    Isbn = book.Isbn
                }));
                return Ok(new { BookId = bookId });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}