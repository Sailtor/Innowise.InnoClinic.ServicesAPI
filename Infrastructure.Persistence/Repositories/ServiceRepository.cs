using Core.Entities;
using Core.Repositories;
using Dapper;
using System.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DapperContext _context;
        public ServiceRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = _context.CreateConnection();
            var services = await connection.QueryAsync<Service>("dbo.SelectAllServices", commandType: CommandType.StoredProcedure);
            return services.ToList();
        }

        public async Task<Service> GetByIdAsync(Guid serviceId, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", serviceId, DbType.Guid);

            using var connection = _context.CreateConnection();
            var service = await connection.QuerySingleOrDefaultAsync<Service>("dbo.SelectService", parameters, commandType: CommandType.StoredProcedure);
            return service;
        }

        public async Task<Service> AddAsync(Service service, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", service.Name, DbType.String);
            parameters.Add("Price", service.Price, DbType.Decimal);
            parameters.Add("IsActive", service.IsActive, DbType.Boolean);
            parameters.Add("CategoryId", service.CategoryId, DbType.Guid);
            parameters.Add("SpecializationId", service.SpecializationId, DbType.Guid);

            using var connection = _context.CreateConnection();
            return await connection.QuerySingleAsync<Service>("dbo.InsertService", parameters, commandType: CommandType.StoredProcedure);
        }
        public void Update(Service service)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", service.Name, DbType.String);
            parameters.Add("Price", service.Price, DbType.Decimal);
            parameters.Add("IsActive", service.IsActive, DbType.Boolean);
            parameters.Add("CategoryId", service.CategoryId, DbType.Guid);
            parameters.Add("SpecializationId", service.SpecializationId, DbType.Guid);
            parameters.Add("Original_Id", service.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.UpdateService", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Remove(Service service)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Original_Id", service.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.DeleteService", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
