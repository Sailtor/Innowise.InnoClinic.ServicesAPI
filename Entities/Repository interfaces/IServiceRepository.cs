using Core.Entities;

namespace Core.Repository_interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Service> GetByIdAsync(Guid serviceId, CancellationToken cancellationToken = default);
        Task<Service> AddAsync(Service service, CancellationToken cancellationToken);
        void Update(Service service);
        void Remove(Service service);
    }
}
