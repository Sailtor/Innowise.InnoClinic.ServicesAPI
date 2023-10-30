namespace Core.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(Guid categoryId)
            : base($"The category with the identifier {categoryId} was not found.")
        {
        }
    }
}
