namespace Core.Exceptions
{
    public sealed class SpecializationNotFoundException : NotFoundException
    {
        public SpecializationNotFoundException(Guid specializationId)
            : base($"The specialization with the id {specializationId} was not found.")
        {
        }
    }
}
