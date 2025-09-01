using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Entities;

namespace IMS.Application.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<List<Authors>> GetAllAuthors();
        Task<int> AddAuthor(Authors authors);
        
    }
}
