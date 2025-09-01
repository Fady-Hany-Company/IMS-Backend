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
    public class GenresRepository : BaseRepository, IGenresRepository
    {
        public GenresRepository(IDbContextFactory factory, IUnitOfWork uow, ILogger<BaseRepository> logger) : base(
            factory, uow, logger)
        {
        }

        public async Task<int> AddGenre(Genres genres)
        {
            Logger.LogInformation("[Repo] AddGenre");
            const string storedProcedureName = "[ims].[usp_genre_insert]";
            var param = new DynamicParameters();
            param.Add("@Name", genres.Name);
            param.Add("@Description", genres.Description);
            param.Add("@GenreId", genres.GenreId, direction: ParameterDirection.Output);

            var conn = GetConnection(out var owns);
            await conn.ExecuteAsync(storedProcedureName, param, transaction: Uow.Transaction,
                commandType: CommandType.StoredProcedure);
            var genreId = param.Get<int>("@GenreId");
            return genreId;
        }

        public async Task<Genres> GetGenre(int genreId)
        {
            Logger.LogInformation("[Repo] GetGenre ");
            const string storedProcedureName = "[ims].[usp_genre_get]";
            var param = new DynamicParameters();
            param.Add("@GenreId", genreId);
            var conn = GetConnection(out var owns);
            var genre = await conn.QueryFirstOrDefaultAsync<Genres>(storedProcedureName, param,
                commandType: CommandType.StoredProcedure);
            return genre;
        }

        public async Task<List<Genres>> GetGenres()
        {
            Logger.LogInformation("[Repo] GetGenres");
            const string storedProcedureName = "[ims].[usp_genres_get]";

            var conn = GetConnection(out var owns);
            var genre = await conn.QueryAsync<Genres>(
                storedProcedureName,
                transaction: Uow.Transaction,
                commandType: CommandType.StoredProcedure);
            return genre.ToList();
        }
    }
}