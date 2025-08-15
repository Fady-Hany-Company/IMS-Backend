using AutoMapper;
using IMS.Application.Features.Logging.InsertLog;
using IMS.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Entities;

namespace IMS.Application.Features.Logging.UpdateLog
{
    public class UpdateLogHandler : IRequestHandler<UpdateLogCommand, Unit>
    {
        private readonly ILogRepository _logRepo;
        private readonly IMapper _mapper;

        public UpdateLogHandler(ILogRepository logRepo, IMapper mapper)
        {
            _logRepo = logRepo;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLogCommand request, CancellationToken cancellationToken)
        {
            var log = _mapper.Map<LogEntry>(request.UpdateLogRequest);

            await _logRepo.UpdateLogAsync(log);
            return Unit.Value;
        }
    }
}
