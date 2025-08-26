using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Application.Interfaces;
using IMS.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace IMS.Infrastructure.Repositories
{
    public class AuthorsRepository  : BaseRepository,IAuthorsRepository
    {
        public AuthorsRepository(IDbContextFactory factory, IUnitOfWork uow, ILogger<BaseRepository> logger) : base(factory, uow, logger)
        {
        }
    }
}
