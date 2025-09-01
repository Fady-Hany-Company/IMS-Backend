using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Entities;

namespace IMS.Application.Interfaces
{
    public interface IGenresRepository
    {
        Task<int> AddGenre(Genres genres);
        Task<Genres> GetGenre(int genreId);
        Task<List<Genres>> GetGenres();
    }
}
