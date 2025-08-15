using IMS.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Entities;

namespace IMS.Application.Features.Logging.InsertLog
{
    public class InsertLogHandler : IRequestHandler<InsertLogCommand,int>
    {
        private readonly ILogRepository _logRepo;
        public InsertLogHandler(ILogRepository repo)
        {
            _logRepo = repo;
        }   
        public async Task<int> Handle(InsertLogCommand request, CancellationToken cancellationToken)
        {
            var log = new LogEntry
            {
                LoginName = request.LoginName,
                LogSource = request.LogSource,
                LogLevel = request.LogLevel,
                Message = request.Message,
                Exception = request.Exception,
                HttpMethod = request.HttpMethod,
                EndpointUrl = request.EndpointUrl,
                TimeStamp = DateTime.UtcNow
            };

            return await _logRepo.InsertLogAsync(log);
        }
    }
}
