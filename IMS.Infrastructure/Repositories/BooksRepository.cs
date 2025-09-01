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
    public class BooksRepository : BaseRepository,IBooksRepository
    {
        public BooksRepository(IDbContextFactory factory, IUnitOfWork uow, ILogger<BaseRepository> logger) : base(factory, uow, logger)
        {
        }
        public async Task<Domain.Entities.Books> GetBookById(int bookId)
        {
            Logger.LogInformation("[Repo] Fetching book with ID {BookId}", bookId);
            const string storedProcedureName = "[ims].[usp_book_select_by_id]";
            var param = new DynamicParameters();
            param.Add("@BookId", bookId);
            var conn = GetConnection(out var owns);
            var book = await conn.QueryFirstOrDefaultAsync<Domain.Entities.Books>(
                 storedProcedureName,
                 param,
                 commandType: CommandType.StoredProcedure,
                 transaction: Uow.Transaction // null if not in a UoW, which is fine
             );
            return book;
        }

        public async Task<int> AddBook(Books book)
        {
            Logger.LogInformation("[Repo] Adding Book");
            const string storedProcedureName = "[ims].[usp_book_add]";
            var param = new DynamicParameters();
            param.Add("@Name", book.Name);
            param.Add("@Pages", book.Pages);
            param.Add("@Isbn", book.Isbn);
            param.Add("@PublicationYear", book.PublicationYear);
            param.Add("@Price", book.Price);
            param.Add("@CoverImage", book.CoverImage);
            param.Add("@Description", book.Description);
            param.Add("@CreatedAt", book.CreatedAt);
            param.Add("@CreatedUsername", book.CreatedUsername);
            param.Add("@AuthorId", book.AuthorId);
            param.Add("@GenreId", book.GenreId);
            param.Add("@CategoryId", book.CategoryId);
            param.Add("@PublisherId", book.PublisherId);
            param.Add("@BookId", book.BookId, direction: ParameterDirection.Output);
            var conn = GetConnection(out var owns);
            await conn.ExecuteAsync(storedProcedureName, param, commandType: CommandType.StoredProcedure, transaction: Uow.Transaction);
            var bookId = param.Get<int>("BookId");
            return bookId;
        }
    }
}
