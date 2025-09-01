using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.BooksDTO.GetBook;
using IMS.Application.Interfaces;
using MediatR;

namespace IMS.Application.Features.Books.GetBook
{
    public class GetBookHandler:IRequestHandler<GetBookQuery,Domain.Entities.Books>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IBooksRepository _repository;
        public GetBookHandler(IUnitOfWork uow, IMapper mapper, IBooksRepository repository)
        {
            _uow = uow;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Domain.Entities.Books> Handle(GetBookQuery request, CancellationToken ct)
        {
            await _uow.BeginAsync(ct);
            try
            {
                var book = await _repository.GetBookById(request.BookId);
                
                await _uow.CommitAsync(ct);
                return book;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }
    }
}
