using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.Interfaces;
using MediatR;

namespace IMS.Application.Features.Books.CreateBook
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IBooksRepository _repository;

        public AddBookHandler(IUnitOfWork uow, IMapper mapper, IBooksRepository repository)
        {
            _uow = uow;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await _uow.BeginAsync(cancellationToken);
            try
            {
                var book = _mapper.Map<Domain.Entities.Books>(request.BookRequestDto);
                book.CreatedAt = DateTime.Now;
                book.CreatedUsername = "Fady Hany";
                
                var bookId = await _repository.AddBook(book);
                await _uow.CommitAsync(cancellationToken);
                return bookId;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}