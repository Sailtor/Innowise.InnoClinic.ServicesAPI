using Core.Entities;

namespace Core.Repositories
{
    public interface ISpecializationRepository
    {
        Task<IEnumerable<Specialization>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Specialization> GetByIdAsync(Guid specializationId, CancellationToken cancellationToken = default);
        Task<Specialization> AddAsync(Specialization specialization, CancellationToken cancellationToken);
        void Update(Specialization specialization);
        void Remove(Specialization specialization);
    }
}
