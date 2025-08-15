using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Data;
using IMS.Application.Interfaces;

namespace IMS.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IDbContextFactory ConnectionFactory;
        protected readonly IUnitOfWork Uow;
        protected readonly ILogger<BaseRepository> Logger;

        protected BaseRepository(IDbContextFactory factory,
            IUnitOfWork uow,
            ILogger<BaseRepository> logger)
        {
            ConnectionFactory = factory;
            Uow = uow;
            Logger = logger;
        }
        protected IDbConnection GetConnection(out bool owns)
        {
            if (Uow.Connection is not null)
            {
                owns = false;
                return Uow.Connection;
            }

            owns = true;
            return ConnectionFactory.CreateOpenConnection();
        }

    }
}
