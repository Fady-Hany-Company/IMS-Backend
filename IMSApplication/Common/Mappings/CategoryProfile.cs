using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.Categories.CreateCategory;
using IMS.Application.DTOs.Categories.GetCategories;
using IMS.Domain.Entities;

namespace IMS.Application.Common.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryRequestDto, Categories>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ForMember(dest => dest.CategoryDesc, opt => opt.MapFrom(src => src.CategoryDesc))
                .ReverseMap();

            CreateMap<GetCategoriesResponseDto, Categories>()
                .ReverseMap();
        }
    }
}
