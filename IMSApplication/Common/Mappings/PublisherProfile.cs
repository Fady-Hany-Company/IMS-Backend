using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Entities;
using IMS.Application.DTOs.PublishersDTO.CreatePublisher;
using IMS.Application.DTOs.PublishersDTO.GetPublishers;

namespace IMS.Application.Common.Mappings
{
    public class PublisherProfile: Profile
    {
        public PublisherProfile()
        {
            CreateMap<CreatePublisherRequestDto, Publishers>().ReverseMap();
            CreateMap<GetPublishersResponseDto, Publishers>().ReverseMap();
        }
    }
}
