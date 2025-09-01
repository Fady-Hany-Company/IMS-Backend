using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using IMS.Application.DTOs.BooksDTO.CreateBook;

namespace IMS.Application.Features.Books.CreateBook
{
    public class AddBookValidator : AbstractValidator<AddBookRequestDto>
    {
        public AddBookValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Pages).GreaterThan(0);
            RuleFor(x => x.PublicationYear).InclusiveBetween(1450, DateTime.Now.Year);
        }
    }
}
