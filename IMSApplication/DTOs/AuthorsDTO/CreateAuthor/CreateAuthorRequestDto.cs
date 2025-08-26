using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTOs.AuthorsDTO.CreateAuthor
{
    public class CreateAuthorRequestDto
    {
        public required string Name { get; set; }
        public string? Bio { get; set; }
    }
}
