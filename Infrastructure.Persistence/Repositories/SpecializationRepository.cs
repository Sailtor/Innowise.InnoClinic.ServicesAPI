using Core.Entities;
using Core.Repositories;
using Dapper;
using System.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly DapperContext _context;
        public SpecializationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = _context.CreateConnection();
            var specializations = await connection.QueryAsync<Specialization>("dbo.SelectAllSpecializations", commandType: CommandType.StoredProcedure);
            return specializations.ToList();
        }

        public async Task<Specialization> GetByIdAsync(Guid specializationId, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", specializationId, DbType.Guid);

            using var connection = _context.CreateConnection();
            var specialization = await connection.QuerySingleOrDefaultAsync<Specialization>("dbo.SelectSpecialization", parameters, commandType: CommandType.StoredProcedure);
            return specialization;
        }

        public async Task<Specialization> AddAsync(Specialization specialization, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", specialization.Name, DbType.String);
            parameters.Add("IsActive", specialization.IsActive, DbType.Boolean);

            using var connection = _context.CreateConnection();
            return await connection.QuerySingleAsync<Specialization>("dbo.InsertSpecialization", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Update(Specialization specialization)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", specialization.Name, DbType.String);
            parameters.Add("IsActive", specialization.IsActive, DbType.Boolean);
            parameters.Add("Original_Id", specialization.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.UpdateSpecialization", parameters, commandType: CommandType.StoredProcedure);

        }

        public void Remove(Specialization specialization)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Original_Id", specialization.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.DeleteSpecialization", parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
