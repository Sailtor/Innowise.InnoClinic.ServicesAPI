using Core.Entities;

namespace Core.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Service> GetByIdAsync(Guid serviceId, CancellationToken cancellationToken = default);
        void Update(Service service, CancellationToken cancellationToken = default);
        Task AddAsync(Service service, CancellationToken cancellationToken);
        void Remove(Service service);
    }
}
