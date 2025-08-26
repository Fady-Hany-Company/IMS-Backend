using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.PublishersDTO.GetPublishers;
using MediatR;

namespace IMS.Application.Features.Publishers.GetPublishers
{
    public record GetPublishersQuery():IRequest<List<GetPublishersResponseDto>>;
}
