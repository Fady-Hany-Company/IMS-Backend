using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.Logging.UpdateLog;
using MediatR;

namespace IMS.Application.Features.Logging.UpdateLog
{
    public record UpdateLogCommand(UpdateLogRequestDto UpdateLogRequest) : IRequest<Unit>;
    
}
