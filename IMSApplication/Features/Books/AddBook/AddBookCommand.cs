using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.BooksDTO.CreateBook;
using MediatR;

namespace IMS.Application.Features.Books.CreateBook
{
    public record AddBookCommand(AddBookRequestDto BookRequestDto) : IRequest<int>;
}