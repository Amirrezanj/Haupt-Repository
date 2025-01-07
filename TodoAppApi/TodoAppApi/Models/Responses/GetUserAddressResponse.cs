using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record GetUserAddressResponse(Guid Id, string Street, string HouseNumber, string City,
        string Zipcode, string Country, string Phone)
    {
        public static GetUserAddressResponse FromEntity(AddressEntity entity)
        {
            var response = new GetUserAddressResponse
            (
                entity.Id,
                entity.Street,
                entity.HouseNumber,
                entity.City,
                entity.ZipCode,
                entity.Country,
                entity.Phone
            );
            return response;
        }
    }
}






//public class AddressEntity
//{
//    public Guid Id { get; set; }
//    public required string Street { get; set; }
//    public required string HouseNumber { get; set; }
//    public required string City { get; set; }
//    public required string ZipCode { get; set; }
//    public required string Country { get; set; }
//    public string? Phone { get; set; }

//    // Navigation Property
//    public List<UserEntity> Users { get; set; } = new List<UserEntity>();
//}
