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
    public class BooksRepository : BaseRepository,IBooksRepository
    {
        public BooksRepository(IDbContextFactory factory, IUnitOfWork uow, ILogger<BaseRepository> logger) : base(factory, uow, logger)
        {
        }
    }
}
