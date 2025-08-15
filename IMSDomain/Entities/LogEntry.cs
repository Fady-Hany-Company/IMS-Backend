using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class LogEntry
    {
        public int LogId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public string? LoginName { get; set; }
        public string? LogSource { get; set; }
        public string? HttpMethod { get; set; }
        public string? EndpointUrl { get; set; }
        public string? LogLevel { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public string? Response { get; set; }
    }
}
