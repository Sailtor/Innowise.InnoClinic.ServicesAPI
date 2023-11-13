namespace UseCases.Dtos.ServiceDto
{
    public class ServiceForUpdateDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid SpecializationId { get; set; }

    }
}
