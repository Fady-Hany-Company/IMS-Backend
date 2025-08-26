using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class Genres
    {
        public required int GenreId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
