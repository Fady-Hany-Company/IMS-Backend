using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.CategoriesDTO.GetCategories;
using IMS.Domain.Entities;

namespace IMS.Application.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<int> AddCategoryAsync(Categories category);
        Task<List<GetCategoriesResponseDto>> GetCategoriesAsync();
    }
}
