using System.ComponentModel.DataAnnotations;
using TodoAppApi.Data.Entities;
using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Requests
{
	public record CreateAddressRequest(
		[StringLength(50,MinimumLength =2)]string Street,
        [StringLength(4, MinimumLength = 1)] string HouseNumber,
        [StringLength(25, MinimumLength = 2)] string City,
        [StringLength(5, MinimumLength = 5)] string ZipCode,
        [StringLength(50, MinimumLength = 2)] string Country)
	{
		public static AddressEntity ToEntity(CreateAddressRequest request)
		{
			var entity = new AddressEntity
			{
				Street = request.Street,
				HouseNumber = request.HouseNumber,
				City = request.City,
				ZipCode = request.ZipCode,
				Country = request.Country
			};

			return entity;
		}
	}
}
