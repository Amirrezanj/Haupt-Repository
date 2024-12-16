using System;
using System.Collections.Generic;

namespace ConsoleApp1.Data;

public partial class Address
{
    public string Id { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
