using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.BooksDTO.GetBook;
using MediatR;

namespace IMS.Application.Features.Books.GetBook
{
    public record GetBookQuery(int BookId) : IRequest<Domain.Entities.Books>;
}
