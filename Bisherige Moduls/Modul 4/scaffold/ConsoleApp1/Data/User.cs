using System;
using System.Collections.Generic;

namespace ConsoleApp1.Data;

public partial class User
{
    public string Id { get; set; } = null!;

    public string FirstNumber { get; set; } = null!;

    public string? SecondName { get; set; }

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AddressId { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;
}
