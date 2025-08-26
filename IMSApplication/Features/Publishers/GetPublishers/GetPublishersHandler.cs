using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.PublishersDTO.GetPublishers;
using IMS.Application.Interfaces;
using MediatR;

namespace IMS.Application.Features.Publishers.GetPublishers
{
    public class GetPublishersHandler : IRequestHandler<GetPublishersQuery, List<GetPublishersResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IPublishersRepository _repository;
        private readonly IMapper _mapper;
        public GetPublishersHandler(IUnitOfWork uow, IPublishersRepository repository, IMapper mapper)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetPublishersResponseDto>> Handle(GetPublishersQuery request, CancellationToken ct)
        {
            await _uow.BeginAsync(ct);
            try
            {
                var publishers = await _repository.GetPublishersAsync();
                var publishersDto = _mapper.Map<List<GetPublishersResponseDto>>(publishers);
                await _uow.CommitAsync(ct);
                return publishersDto;
            }
            catch (Exception e)
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }
    }
}
