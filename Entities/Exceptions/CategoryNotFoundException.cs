namespace Core.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(Guid categoryId)
            : base($"The category with the id {categoryId} was not found.")
        {
        }
    }
}
