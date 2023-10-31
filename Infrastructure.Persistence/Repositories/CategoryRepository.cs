using Core.Entities;
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
            var query = "SELECT * FROM catrgories";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Category>(query);
                return companies.ToList();
            }
        }

        public async Task<Category> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            var query = "SELECT * FROM catrgories WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Category>(query, new { categoryId });
                return company;
            }
        }
        public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            var query = "INSERT INTO catrgories (Id, Name, TimeSlotSize) VALUES (NEWGUID(), @Name, @TimeSlotSize)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", category.Name, DbType.String);
            parameters.Add("TimeSlotSize", category.TimeSlotSize, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public void Update(Category category, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
