using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTOs.GenresDTO.CreateGenre
{
    public class CreateGenreRequestDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
