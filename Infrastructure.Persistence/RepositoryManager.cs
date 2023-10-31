using Core.Repositories;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IServiceRepository> _lazyServiceRepository;
        private readonly Lazy<ISpecializationRepository> _lazySpecializationRepository;
        private readonly Lazy<ICategoryRepository> _lazyCategoryRepository;

        public RepositoryManager(DapperContext dbContext)
        {
            _lazyServiceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(dbContext));
            _lazySpecializationRepository = new Lazy<ISpecializationRepository>(() => new SpecializationRepository(dbContext));
            _lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dbContext));
        }

        public IServiceRepository ServiceRepository => _lazyServiceRepository.Value;
        public ISpecializationRepository SpecializationRepository => _lazySpecializationRepository.Value;
        public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;
    }
}
