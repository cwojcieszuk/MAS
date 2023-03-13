using Microsoft.EntityFrameworkCore;
using MP5.Models;

namespace MP5.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Player> Players { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<PlayerCoupon> PlayerCoupons { get; set; }
    public DbSet<Bet> Bets { get; set; }
    public DbSet<BetCoupon> BetCoupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>(p =>
        {
            p.HasKey(e => e.IdPlayer);
            p.Property(e => e.FirstName).IsRequired();
            p.Property(e => e.LastName).IsRequired();
            p.Property(e => e.Email).IsRequired();
            p.Property(e => e.PhoneNumber).IsRequired();
            p.Property(e => e.BirthDate).IsRequired();
            p.Property(e => e.Age).IsRequired();

            p.HasData(new Player
            {
                IdPlayer = 1, 
                FirstName = "Jan", 
                LastName = "Kowalski", 
                Email = "jan@gmail.com",
                PhoneNumber = 123456789, 
                BirthDate = DateTime.Parse("1984-02-03")
            });
        });

        modelBuilder.Entity<PlayerCoupon>(p =>
        {
            p.HasKey(e => new { e.IdPlayer, e.IdCoupon });
            p.Property(e => e.Amount).IsRequired();

            p.HasOne(e => e.Player).WithMany(e => e.PlayerCoupons).HasForeignKey(e => e.IdPlayer);
            p.HasOne(e => e.Coupon).WithMany(e => e.PlayerCoupons).HasForeignKey(e => e.IdCoupon);
        });

        modelBuilder.Entity<Coupon>(b =>
        {
            b.HasKey(e => e.IdCoupon);
            b.Property(e => e.Date).IsRequired();
        });

        modelBuilder.Entity<Bet>(b =>
        {
            b.HasKey(e => e.IdBet);
            b.HasDiscriminator(e => e.BetType);
            b.Property(e => e.Category).IsRequired();
            b.Property(e => e.Rate).IsRequired();
            b.Property(e => e.SportName);
            b.Property(e => e.EventName);
        });

        modelBuilder.Entity<BetCoupon>(b =>
        {
            b.HasKey(e => new { e.IdBet, e.IdCoupon });

            b.HasOne(e => e.Bet).WithMany(e => e.BetCoupons).HasForeignKey(e => e.IdBet);
            b.HasOne(e => e.Coupon).WithMany(e => e.BetCoupons).HasForeignKey(e => e.IdCoupon);
        });
    }
}