using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Address
{
    public int IdAddress { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string State { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
