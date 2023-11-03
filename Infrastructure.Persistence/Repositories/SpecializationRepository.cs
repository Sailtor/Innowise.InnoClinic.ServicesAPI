using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Persistence.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly DapperContext _context;
        public SpecializationRepository(DapperContext context)
        {
            _context = context;
        }

        public Task<Specialization> AddAsync(Specialization specialization, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Specialization>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Specialization> GetByIdAsync(Guid specializationId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public void Update(Specialization specialization)
        {
            throw new NotImplementedException();
        }
    }
}
