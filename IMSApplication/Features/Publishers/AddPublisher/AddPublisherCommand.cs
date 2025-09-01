using IMS.Application.DTOs.PublishersDTO.CreatePublisher;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Publishers.CreatePublisher
{
    public record AddPublisherCommand(AddPublisherRequestDto AddPublisher):IRequest<int>;
}
