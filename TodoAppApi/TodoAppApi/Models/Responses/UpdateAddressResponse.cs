using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record UpdateAddressResponse(Guid Id, string Street, string HouseNumber,
        string City, string ZipCode, string Country)
    {
        public static UpdateAddressResponse FromEntity(AddressEntity entity)
        {
            var response = new UpdateAddressResponse(
                entity.Id,
                entity.Street,
                entity.HouseNumber,
                entity.City,
                entity.ZipCode,
                entity.Country
            );

            return response;
        }
    }
}
