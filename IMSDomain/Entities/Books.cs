using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class Books
    {
        public required int BookId { get; set; }
        public required string Name { get; set; }
        public required int Pages { get; set; }
        public required string Isbn { get; set; }
        public required int PublicationYear { get; set; }
        public required decimal Price { get; set; }
        public string? CoverImage { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Today;
        public required string CreatedUsername { get; set; }

        public required int AuthorId { get; set; }
        public required int GenreId { get; set; }
        public required int CategoryId { get; set; }
        public required int PublisherId { get; set; }
    }
}
