namespace Core.Repositories
{
    public interface IRepositoryManager
    {
        ISpecializationRepository SpecializationRepository { get; }
        IServiceRepository ServiceRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUnitOfWork UnitOfWork { get; }

    }
}
