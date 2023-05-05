using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public virtual User IdAdminNavigation { get; set; } = null!;
}
