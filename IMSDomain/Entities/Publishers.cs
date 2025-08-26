using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class Publishers
    {
        [Key]
        public required int PublisherId { get; set; }

        public required string Name { get; set; }
    }
}
