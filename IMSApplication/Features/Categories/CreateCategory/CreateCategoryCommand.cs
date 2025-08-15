using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.Categories.CreateCategory;
using MediatR;

namespace IMS.Application.Features.Categories.CreateCategory
{
    public  record CreateCategoryCommand(CreateCategoryRequestDto category) : IRequest<int>;

}
