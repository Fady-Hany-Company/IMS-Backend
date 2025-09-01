using AutoMapper;
using IMS.Application.DTOs.BooksDTO.CreateBook;
using IMS.Application.DTOs.BooksDTO.GetBook;
using IMS.Domain.Entities;

namespace IMS.Application.Common.Mappings;

public class BooksProfile:Profile
{
    public BooksProfile()
    {
        CreateMap<AddBookRequestDto, Books>()
            .ReverseMap();
        
        CreateMap<GetBookResponseDto, Books>()
            .ReverseMap();
    }
}