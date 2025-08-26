using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.Interfaces;
using MediatR;

namespace IMS.Application.Features.Publishers.CreatePublisher
{
    public class CreatePublisherHandler : IRequestHandler<CreatePublisherCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IPublishersRepository _repository;

        public CreatePublisherHandler(IUnitOfWork uow,IPublishersRepository publishersRepository,IMapper mapper)
        {
            _uow = uow;
            _repository = publishersRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreatePublisherCommand request, CancellationToken ct)
        {
            await _uow.BeginAsync(ct);
            try
            {
                var publisher = _mapper.Map<Domain.Entities.Publishers>(request.CreatePublisher);
                
                var publisherId = await _repository.CreatePublisherAsync(publisher);
                await _uow.CommitAsync(ct);
                return publisherId;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }
    }
}
