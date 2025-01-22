using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Models
{
    public record CreateAddressRequest(string Street,
        string HouseNumber,
        string City,
        string ZipCode,
        string Country);
}