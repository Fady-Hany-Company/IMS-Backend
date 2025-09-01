using AutoMapper;
using IMS.Application.DTOs.BooksDTO.CreateBook;
using IMS.Domain.Entities;

namespace IMS.Application.Common.Mappings;

public class BooksProfile:Profile
{
    public BooksProfile()
    {
        CreateMap<AddBookRequestDto, Books>()
            .ReverseMap();
    }
}