using IMS.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IMS.Domain.Entities;
using IMS.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace IMS.Infrastructure.Repositories
{
    public class LogRepository : BaseRepository, ILogRepository
    {
        public LogRepository(IDbContextFactory factory, IUnitOfWork uow, ILogger<BaseRepository> logger)
            : base(factory, uow, logger) { }

        public async Task<int> InsertLogAsync(LogEntry log)
        {
            Logger.LogInformation("[Repo] Inserting new Logger {endpoint_url}", log.EndpointUrl);
            const string sql = @"
                INSERT INTO ims.logger_table (
                    login_name,
                    log_source,
                    http_method,
                    endpoint_url
                )
                OUTPUT Inserted.log_id
                VALUES (
                    @LoginName,
                    @LogSource,
                    @HttpMethod,
                    @EndpointUrl
                );
            ";

            var connection = GetConnection(out var owns);
            try
            {
                var logId = await connection.QuerySingleAsync<int>(sql, log, transaction: Uow.Transaction);
                Logger.LogInformation("[Repo] Inserted Log successfully with ID {logId}", logId);
                return logId;
            }
            finally
            {
                if (owns) connection.Dispose();
            }
        }

        public async Task UpdateLogAsync(LogEntry logEntry)
        {
            Logger.LogInformation("[Repo] Updating Logger {logId}", logEntry.LogId);
            const string sql = @"
            UPDATE ims.logger_table
            SET log_level = @LogLevel,
                message   = @Message,
                exception = @Exception,
                response  = @Response
            WHERE log_id = @LogId;
        ";

            var connection = GetConnection(out var owns);
            try
            {
                await connection.ExecuteAsync(sql, logEntry, transaction: Uow.Transaction);
                Logger.LogInformation("[Repo] Updated Log successfully with ID {logId}", logEntry.LogId);
            }
            finally
            {
                if (owns) connection.Dispose();
            }
        }
    }
}
