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
    public class AuthorsRepository : BaseRepository, IAuthorsRepository
    {
        public AuthorsRepository(IDbContextFactory factory, IUnitOfWork uow, ILogger<BaseRepository> logger) : base(
            factory, uow, logger)
        {
        }

        public async Task<List<Authors>> GetAllAuthors()
        {
            Logger.LogInformation("[Repo] Starting GetAllGenres");
            var storedProcedureName = "[ims].[usp_authors_get_all]";
            var conn = GetConnection(out var owns);
            var authors = await conn.QueryAsync<Authors>(
                storedProcedureName, 
                transaction: Uow.Transaction,
                commandType: CommandType.StoredProcedure);
            Logger.LogInformation("[Repo] Finished GetAllGenres");
            return authors.ToList();
        }

        public async Task<int> AddAuthor(Authors author)
        {
            Logger.LogInformation("[Repo] Starting AddAuthor");
            var storedProcedureName = "[ims].[usp_author_insert]";
            var param = new DynamicParameters();
            param.Add("@Name", author.Name);
            param.Add("@Bio", author.Bio);
            param.Add("@AuthorId", author.AuthorId, direction: ParameterDirection.Output);

            var conn = GetConnection(out var owns);
            await conn.ExecuteAsync(
                storedProcedureName,
                param,
                transaction: Uow.Transaction,
                commandType: CommandType.StoredProcedure);
            var authorId = param.Get<int>("@AuthorId");
            Logger.LogInformation("[Repo] Finished AddAuthor");
            return authorId;
        }
    }
}