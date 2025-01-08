using TodoAppApi.Data.Entities;
using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Requests
{
	public record CreateAddressRequest(
		string Street,
		string HouseNumber,
		string City,
		string ZipCode,
		string Country)
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
