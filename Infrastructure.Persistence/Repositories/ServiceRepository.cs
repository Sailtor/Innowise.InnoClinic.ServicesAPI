using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DapperContext _context;
        public ServiceRepository(DapperContext context)
        {
            _context = context;
        }

        public Task<Service> AddAsync(Service service, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Service>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetByIdAsync(Guid serviceId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(Service service)
        {
            throw new NotImplementedException();
        }

        public void Update(Service service)
        {
            throw new NotImplementedException();
        }
    }
}
