using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.GenresDTO.GetGenres;
using IMS.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IMS.Application.Features.Genres.GetGenres
{
    public class GetGenresHandler : IRequestHandler<GetGenresQuery, List<GetGenresResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenresRepository _repository;
        private readonly ILogger<GetGenresHandler> _logger;

        public GetGenresHandler(IUnitOfWork uow, IMapper mapper, IGenresRepository repository, ILogger<GetGenresHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<GetGenresResponseDto>> Handle(GetGenresQuery request, CancellationToken ct)
        {
            await _uow.BeginAsync(ct);
            try
            {
                _logger.LogInformation("[Handler] Starting GetGenresHandler");
                var genres = await _repository.GetGenres();
                var response = _mapper.Map<List<GetGenresResponseDto>>(genres);
                await _uow.CommitAsync(ct);
                _logger.LogInformation("[Handler] Successfully GetGenresHandler");
                return response;
            }
            catch (Exception)
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }
    }
}