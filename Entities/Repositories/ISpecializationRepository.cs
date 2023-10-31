using Core.Entities;

namespace Core.Repositories
{
    public interface ISpecializationRepository
    {
        Task<IEnumerable<Specialization>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Specialization> GetByIdAsync(Guid specializationId, CancellationToken cancellationToken = default);
        void Update(Specialization specialization, CancellationToken cancellationToken = default);
        Task AddAsync(Specialization specialization, CancellationToken cancellationToken);
        void Remove(Specialization specialization);
    }
}
