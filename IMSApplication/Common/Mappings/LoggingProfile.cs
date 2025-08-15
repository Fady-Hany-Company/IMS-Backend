using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.Logging.UpdateLog;
using IMS.Domain.Entities;

namespace IMS.Application.Common.Mappings
{
    public class LoggingProfile : Profile
    {
        public LoggingProfile()
        {
            CreateMap<UpdateLogRequestDto, LogEntry>().ReverseMap();
        }
    }
}
