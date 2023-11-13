namespace Core.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
