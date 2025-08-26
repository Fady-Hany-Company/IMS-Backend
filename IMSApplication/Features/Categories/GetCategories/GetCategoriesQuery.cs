using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.CategoriesDTO.GetCategories;
using MediatR;

namespace IMS.Application.Features.Categories.GetCategories
{
    public record GetCategoriesQuery():IRequest<List<GetCategoriesResponseDto>>;

}
