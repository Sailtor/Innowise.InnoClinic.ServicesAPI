namespace Core.Exceptions
{
    public sealed class ServiceNotFoundException : NotFoundException
    {
        public ServiceNotFoundException(Guid serviceId)
            : base($"The service with the identifier {serviceId} was not found.")
        {
        }
    }
}
