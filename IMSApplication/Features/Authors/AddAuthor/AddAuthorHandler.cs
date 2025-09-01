using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IMS.Application.Features.Authors.CreateAuthor
{
    public class AddAuthorHandler:IRequestHandler<AddAuthorCommand, int>
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly ILogger<AddAuthorHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddAuthorHandler(IAuthorsRepository authorsRepository,ILogger<AddAuthorHandler> logger,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _authorsRepository = authorsRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddAuthorCommand request, CancellationToken ct)
        {
            await _unitOfWork.BeginAsync(ct);
            try
            {
                _logger.LogInformation("[Handler] Starting AddAuthorHandler");
                var author = _mapper.Map<Domain.Entities.Authors>(request.RequestDto);
                var authorId = await _authorsRepository.AddAuthor(author);
                await _unitOfWork.CommitAsync(ct);
                _logger.LogInformation("[Handler] Successfully AddAuthorHandler");
                return authorId;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync(ct);
                throw;
            }
        }
    }
}
