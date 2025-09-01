using AutoMapper;
using IMS.Application.DTOs.GenresDTO.CreateGenre;
using IMS.Application.DTOs.GenresDTO.GetGenres;
using IMS.Domain.Entities;

namespace IMS.Application.Common.Mappings;

public class GenreProfile:Profile
{
    public GenreProfile()
    {
        CreateMap<AddGenreRequestDto, Genres>()
            .ReverseMap();
        
        CreateMap<GetGenresResponseDto, Genres>()
            .ReverseMap();
    }
}