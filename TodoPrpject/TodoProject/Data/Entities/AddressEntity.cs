namespace TodoProject.Data.Entities;

public class AddressEntity
{
    public Guid Id { get; set; }
    public required string Street { get; set; }
    public required string HouseNumber { get; set; }
    public required string City { get; set; }
    public required string ZipCode { get; set; }
    public required string Country { get; set; }
    public string? Phone { get; set; }

    // Navigation Property
    public List<UserEntity> Users { get; set; } = new List<UserEntity>();
}
