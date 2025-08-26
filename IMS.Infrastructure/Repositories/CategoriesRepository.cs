using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IMS.Application.DTOs.Categories.CreateCategory;
using IMS.Application.DTOs.CategoriesDTO.GetCategories;
using IMS.Application.Interfaces;
using IMS.Domain.Entities;
using IMS.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace IMS.Infrastructure.Repositories
{
    public class CategoriesRepository : BaseRepository, ICategoriesRepository
    {
        public CategoriesRepository(IDbContextFactory factory,
            IUnitOfWork uow,
            ILogger<BaseRepository> logger)
            : base(factory, uow, logger) { }

        public async Task<int> CreateAsync(Categories category)
        {
            Logger.LogInformation("[Repo] Creating new category {CategoryName}", category.CategoryName);

            const string storedProcedureName = "[ims].[usp_category_insert]";
            var param = new DynamicParameters();
            param.Add("@CategoryName", category.CategoryName);
            param.Add("@CategoryDesc", category.CategoryDesc);
            param.Add("@CreatedAt", category.CreatedAt);
            param.Add("@CategoryId", category.CategoryId, direction: ParameterDirection.Output);


            var conn = GetConnection(out var owns);

            await conn.ExecuteAsync(
                storedProcedureName,
                param,
                commandType: CommandType.StoredProcedure,
                transaction: Uow.Transaction // null if not in a UoW, which is fine
            );

            var categoryId = param.Get<int>("CategoryId");


            Logger.LogInformation("[Repo] Category created successfully with ID {CategoryId}", categoryId);

            return categoryId;
        }

        public async Task<List<GetCategoriesResponseDto>> GetCategoriesAsync()
        {
            Logger.LogInformation("[Repo] Get all categories");

            const string storedProcedureName = "[ims].[usp_categories_get_all]";

            var conn = GetConnection(out var owns);

            var categories = await conn.QueryAsync<GetCategoriesResponseDto>(
                 storedProcedureName,
                 commandType: CommandType.StoredProcedure,
                 transaction: Uow.Transaction
             );

            
            Logger.LogInformation("[Repo] Get all categories successfully");

            return categories.ToList();
        }
    }
}
