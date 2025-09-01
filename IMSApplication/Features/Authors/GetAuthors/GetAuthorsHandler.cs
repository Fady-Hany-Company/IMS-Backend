using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.AuthorsDTO.GetAuthors;
using IMS.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IMS.Application.Features.Authors.GetAuthors
{
    public class GetAuthorsHandler:IRequestHandler<GetAuthorsQuery,List<Domain.Entities.Authors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper  _mapper;
        private readonly IAuthorsRepository   _authorsRepository;
        private readonly ILogger <GetAuthorsHandler> _logger;

        public GetAuthorsHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthorsRepository  authorsRepository, ILogger <GetAuthorsHandler> logger)
        {
            _mapper =  mapper;
            _unitOfWork = unitOfWork;
            _authorsRepository = authorsRepository;
            _logger = logger;
        }

        public async Task<List<Domain.Entities.Authors>> Handle(GetAuthorsQuery request, CancellationToken ct)
        {
            await _unitOfWork.BeginAsync(ct);
            try
            {
                _logger.LogInformation("[Handler] Starting GetAuthorsHandler");
                var authorsList = await _authorsRepository.GetAllAuthors();
                var authors = _mapper.Map<List<GetAuthorsResponseDto>>(authorsList);
                await _unitOfWork.CommitAsync(ct);
                _logger.LogInformation("[Handler] Successfully GetAuthorsHandler");
                return authorsList;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(ct);
                throw;
            }
        }
    }
}
