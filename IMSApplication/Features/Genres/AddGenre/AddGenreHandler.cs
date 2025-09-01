using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.Interfaces;
using MediatR;

namespace IMS.Application.Features.Genres.CreateGenre
{
    public class AddGenreHandler:IRequestHandler<AddGenreCommand,int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenresRepository  _repository;

        public AddGenreHandler(IUnitOfWork uow,IGenresRepository repository,IMapper mapper)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddGenreCommand request, CancellationToken ct)
        {
            await _uow.BeginAsync(ct);
            try
            {
                var genre = _mapper.Map<Domain.Entities.Genres>(request.RequestDto);
                
                var genreId = await _repository.AddGenre(genre);
                await _uow.CommitAsync(ct);
                return genreId;
            }
            catch (Exception e)
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }
    }
}
