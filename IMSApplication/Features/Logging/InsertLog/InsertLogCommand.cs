using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IMS.Application.Features.Logging.InsertLog
{
    public record InsertLogCommand(
        string? LoginName,
        string? LogSource,
        string? HttpMethod,
        string? EndpointUrl,
        string? LogLevel,
        string? Message,
        string? Exception,
        string? Response
    ) : IRequest<int>;
}
