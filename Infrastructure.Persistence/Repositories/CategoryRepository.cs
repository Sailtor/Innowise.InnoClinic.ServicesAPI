﻿using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using Dapper;
using System.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;
        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = _context.CreateConnection();
            var companies = await connection.QueryAsync<Category>("dbo.SelectAllCategories", commandType: CommandType.StoredProcedure);
            return companies.ToList();
        }

        public async Task<Category> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", categoryId, DbType.Guid);

            using var connection = _context.CreateConnection();
            var category = await connection.QuerySingleAsync<Category>("dbo.SelectCategory", parameters, commandType: CommandType.StoredProcedure);
            return category;
        }
        public async Task<Category> AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", category.Name, DbType.String);
            parameters.Add("TimeSlotSize", category.TimeSlotSize, DbType.Int32);

            using var connection = _context.CreateConnection();
            return await connection.QuerySingleAsync<Category>("dbo.InsertCategory", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Update(Category category)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", category.Name, DbType.String);
            parameters.Add("TimeSlotSize", category.TimeSlotSize, DbType.Int32);
            parameters.Add("Original_Id", category.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.UpdateCategory", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Remove(Category category)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Original_Id", category.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.DeleteCategory", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
