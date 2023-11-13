namespace Core.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        ISpecializationRepository SpecializationRepository { get; }
        IServiceRepository ServiceRepository { get; }
        ICategoryRepository CategoryRepository { get; }
    }
}
