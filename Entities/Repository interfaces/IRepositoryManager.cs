namespace Core.Repository_interfaces
{
    public interface IRepositoryManager
    {
        ISpecializationRepository SpecializationRepository { get; }
        IServiceRepository ServiceRepository { get; }
        ICategoryRepository CategoryRepository { get; }
    }
}
