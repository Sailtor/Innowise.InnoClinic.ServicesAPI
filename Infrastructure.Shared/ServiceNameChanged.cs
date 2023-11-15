namespace Infrastructure.Shared
{
    public interface ServiceNameChanged
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
