using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.Categories.CreateCategory;
using IMS.Domain.Entities;

namespace IMS.Application.Common.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryRequestDto, Categories>()
                .ReverseMap();
        }
    }
}
