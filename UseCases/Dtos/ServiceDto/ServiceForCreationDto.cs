namespace UseCases.Dtos.ServiceDto
{
    public class ServiceForCreationDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
