namespace UseCases.Dtos.ServiceDto
{
    public class ServiceForResponseDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
