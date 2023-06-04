using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Account
{
    public int IdAccount { get; set; }

    public double Money { get; set; }

    public string? BankAccount { get; set; }
    
    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
