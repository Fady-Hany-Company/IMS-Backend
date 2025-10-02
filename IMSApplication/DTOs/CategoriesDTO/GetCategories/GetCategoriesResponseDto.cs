using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTOs.CategoriesDTO.GetCategories
{
    public class GetCategoriesResponseDto
    {
        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public string? CategoryDesc { get; set; }
        public required string CreatedAt { get; set; }
    }
}
