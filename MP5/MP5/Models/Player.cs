namespace MP5.Models;

public class Player
{
    public int IdPlayer { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public int Age { get; set; }
    public virtual ICollection<PlayerCoupon> PlayerCoupons { get; set; }
}