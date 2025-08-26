using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTOs.GenresDTO.GetGenre
{
    public class GetGenreResponseDto
    {
        public required int GenreId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
