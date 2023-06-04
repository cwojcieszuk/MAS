using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Pesel { get; set; }
    
    public string Login { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int PhoneNumber { get; set; }
    
    public int Age { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string RefreshToken { get; set; } = null!;

    public DateTime RefreshTokenExpiration { get; set; }
    
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    
    public virtual Account Account { get; set; }
    public virtual Admin? Admin { get; set; }

    public virtual Player? Player { get; set; }

    public virtual ICollection<PlayerBet> PlayerBets { get; set; } = new List<PlayerBet>();
}
