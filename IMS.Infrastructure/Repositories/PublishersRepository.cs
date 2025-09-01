using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;
using IMS.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace IMS.Infrastructure.Repositories
{
    public class PublishersRepository : BaseRepository, IPublishersRepository
    {
        public PublishersRepository(IDbContextFactory factory, IUnitOfWork uow, ILogger<BaseRepository> logger) : base(factory, uow, logger)
        {
        }

        public async Task<int> AddPublisherAsync(Publishers publishers)
        {
            Logger.LogInformation("[Repo] Creating new publisher {publisherName}", publishers.Name);

            const string storedProcedureName = "[ims].[usp_publisher_insert]";
            var param = new DynamicParameters();
            param.Add("@Name", publishers.Name);
            param.Add("@PublisherId", publishers.PublisherId, direction: ParameterDirection.Output);

            var conn = GetConnection(out var owns);

            await conn.ExecuteAsync(
                storedProcedureName,
                param,
                commandType: CommandType.StoredProcedure,
                transaction: Uow.Transaction // null if not in a UoW, which is fine
            );

            var publisherId = param.Get<int>("PublisherId");


            Logger.LogInformation("[Repo] Publisher created successfully with ID {PublisherId}", publisherId);

            return publisherId;
        }

        public async Task<List<Publishers>> GetPublishersAsync()
        {
            Logger.LogInformation("[Repo] Selecting all publishers");

            const string storedProcedureName = "[ims].[usp_publishers_select_all]";

            var conn = GetConnection(out var owns);

            var publishers = await conn.QueryAsync<Publishers>(
                 storedProcedureName,
                 commandType: CommandType.StoredProcedure,
                 transaction: Uow.Transaction // null if not in a UoW, which is fine
             );



            Logger.LogInformation("[Repo] Selecting all publishers successfully ");

            return publishers.ToList();
        }
    }
}
