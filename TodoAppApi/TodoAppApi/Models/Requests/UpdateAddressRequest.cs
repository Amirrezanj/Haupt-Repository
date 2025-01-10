using System.ComponentModel.DataAnnotations;

namespace TodoAppApi.Models.Requests
{
    public record UpdateAddressRequest(
        Guid Id,
        [StringLength(50, MinimumLength = 2)] string Street,
        [StringLength(4, MinimumLength = 1)] string HouseNumber,
        [StringLength(25, MinimumLength = 2)] string City,
        [StringLength(5, MinimumLength = 5)] string ZipCode,
        [StringLength(50, MinimumLength = 2)] string Country)
    {
    }
}
