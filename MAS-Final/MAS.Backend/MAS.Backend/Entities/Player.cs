using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Player
{
    public int IdPlayer { get; set; }

    public virtual User IdPlayerNavigation { get; set; } = null!;
}
