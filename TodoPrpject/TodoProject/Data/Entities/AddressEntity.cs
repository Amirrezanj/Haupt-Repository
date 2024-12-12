
namespace TodoProject.Data.Entities
{
    public class AddressEntity
    {
        public Guid ID { get; set; }
        public required string Street { get; set; }
        public required int HouseNumber { get; set; }
        public required string City { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }

        
    }
}
