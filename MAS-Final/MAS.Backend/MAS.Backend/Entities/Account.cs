using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Account
{
    public int IdAccount { get; set; }

    public double Money { get; set; }

    public string BankAccount { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
