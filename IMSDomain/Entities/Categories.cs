using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public string? CategoryDesc { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
