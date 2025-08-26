using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTOs.BooksDTO.GetBook
{
    public class GetBookResponseDto
    {
        public required int BookId { get; set; }
        public required string Name { get; set; }
        public required int Pages { get; set; }
        public required int AuthorId { get; set; }
        public required int GenreId { get; set; }
        public string? Isbn { get; set; }
        public required int CategoryId { get; set; }
        public required int PublisherId { get; set; }
        public required int PublicationYear { get; set; }
        public required decimal Price { get; set; }
        public string? CoverImage { get; set; }
        public string? Description { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.Today;
        public required string CreatedUsername { get; set; }
    }
}
