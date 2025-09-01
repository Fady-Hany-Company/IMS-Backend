using AutoMapper;
using IMS.Application.DTOs.AuthorsDTO.CreateAuthor;
using IMS.Application.DTOs.AuthorsDTO.GetAuthor;
using IMS.Application.DTOs.AuthorsDTO.GetAuthors;
using IMS.Domain.Entities;

namespace IMS.Application.Common.Mappings;

public class AuthorsProfile:Profile
{
    public AuthorsProfile()
    {
        CreateMap<AddAuthorRequestDto,Authors>()
            .ReverseMap();
        
        CreateMap<GetAuthorsResponseDto,Authors>()
            .ReverseMap();
        
        CreateMap<GetAuthorResponseDto,Authors>()
            .ReverseMap();
    }
}