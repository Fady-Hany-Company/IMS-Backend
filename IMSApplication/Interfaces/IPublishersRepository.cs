using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.DTOs.Publishers.GetPublishers;
using IMS.Domain.Entities;

namespace IMS.Application.Interfaces
{
    public interface IPublishersRepository
    {
        Task<int> CreatePublisherAsync(Publishers publishers);
        Task<List<Publishers>> GetPublishersAsync();
    }
}
