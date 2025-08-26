using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTOs.LoggingDTO.UpdateLog
{
    public class UpdateLogRequestDto
    {
        public int LogId { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Response { get; set; }

    }
}
