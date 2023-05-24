using System;
using System.Collections.Generic;
using MAS.Backend.Data.Seeds;
using MAS.Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAS.Backend.Data;

public partial class MasContext : DbContext
{
    public MasContext()
    {
    }

    public MasContext(DbContextOptions<MasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bet> Bets { get; set; }

    public virtual DbSet<BetCoupon> BetCoupons { get; set; }

    public virtual DbSet<BetEsport> BetEsports { get; set; }

    public virtual DbSet<BetEsportOption> BetEsportOptions { get; set; }

    public virtual DbSet<BetEsportType> BetEsportTypes { get; set; }

    public virtual DbSet<BetSport> BetSports { get; set; }

    public virtual DbSet<BetSportOption> BetSportOptions { get; set; }

    public virtual DbSet<BetSportType> BetSportTypes { get; set; }

    public virtual DbSet<BetStatus> BetStatuses { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<CouponOffer> CouponOffers { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerBet> PlayerBets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("Account_pk");

            entity.ToTable("Account");

            entity.Property(e => e.BankAccount)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Account)
                .HasForeignKey<Account>(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Account_User");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("Address_pk");

            entity.ToTable("Address");

            entity.Property(e => e.City)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Address_User");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("Admin_pk");

            entity.ToTable("Admin");

            entity.Property(e => e.IdAdmin).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdAdminNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Admin_User");
        });

        modelBuilder.Entity<Bet>(entity =>
        {
            entity.HasKey(e => e.IdBet).HasName("Bet_pk");

            entity.ToTable("Bet");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.IdBetEsportNavigation).WithMany(p => p.Bets)
                .HasForeignKey(d => d.IdBetEsport)
                .HasConstraintName("Bet_BetEsport");

            entity.HasOne(d => d.IdBetSportNavigation).WithMany(p => p.Bets)
                .HasForeignKey(d => d.IdBetSport)
                .HasConstraintName("Bet_BetSport");
            entity.Seed();
        });

        modelBuilder.Entity<BetCoupon>(entity =>
        {
            entity.HasKey(e => new { e.IdBetCoupon, e.IdCoupon }).HasName("BetCoupon_pk");

            entity.ToTable("BetCoupon");

            entity.Property(e => e.IdBetCoupon).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdBetEsportOptionNavigation).WithMany(p => p.BetCoupons)
                .HasForeignKey(d => d.IdBetEsportOption)
                .HasConstraintName("BetCoupon_BetEsportOption");

            entity.HasOne(d => d.IdBetSportOptionNavigation).WithMany(p => p.BetCoupons)
                .HasForeignKey(d => d.IdBetSportOption)
                .HasConstraintName("BetCoupon_BetSportOption");

            entity.HasOne(d => d.IdCouponNavigation).WithMany(p => p.BetCoupons)
                .HasForeignKey(d => d.IdCoupon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BetCoupon_Coupon");
        });

        modelBuilder.Entity<BetEsport>(entity =>
        {
            entity.HasKey(e => e.IdBetEsport).HasName("BetEsport_pk");

            entity.ToTable("BetEsport");

            entity.Property(e => e.GameName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Team1)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Team2)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Seed();
        });

        modelBuilder.Entity<BetEsportOption>(entity =>
        {
            entity.HasKey(e => e.IdBetEsportOption).HasName("BetEsportOption_pk");

            entity.ToTable("BetEsportOption");

            entity.HasOne(d => d.IdBetEsportNavigation).WithMany(p => p.BetEsportOptions)
                .HasForeignKey(d => d.IdBetEsport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BetEsportOption_BetEsport");

            entity.HasOne(d => d.IdBetEsportTypeNavigation).WithMany(p => p.BetEsportOptions)
                .HasForeignKey(d => d.IdBetEsportType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BetEsportOption_BetEsportType");

            entity.HasOne(d => d.IdBetStatusNavigation).WithMany(p => p.BetEsportOptions)
                .HasForeignKey(d => d.IdBetStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BetEsportOption_BetStatus");
            entity.Seed();
        });

        modelBuilder.Entity<BetEsportType>(entity =>
        {
            entity.HasKey(e => e.IdBetEsportType).HasName("BetEsportType_pk");

            entity.ToTable("BetEsportType");

            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Seed();
        });

        modelBuilder.Entity<BetSport>(entity =>
        {
            entity.HasKey(e => e.IdBetSport).HasName("BetSport_pk");

            entity.ToTable("BetSport");

            entity.Property(e => e.SportName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Team1)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Team2)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Seed();
        });

        modelBuilder.Entity<BetSportOption>(entity =>
        {
            entity.HasKey(e => e.IdBetSportOption).HasName("BetSportOption_pk");

            entity.ToTable("BetSportOption");

            entity.HasOne(d => d.IdBetSportNavigation).WithMany(p => p.BetSportOptions)
                .HasForeignKey(d => d.IdBetSport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BetSportTypeOdds_BetSport");

            entity.HasOne(d => d.IdBetSportTypeNavigation).WithMany(p => p.BetSportOptions)
                .HasForeignKey(d => d.IdBetSportType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BetSportTypeOdds_BetSportType");

            entity.HasOne(d => d.IdBetStatusNavigation).WithMany(p => p.BetSportOptions)
                .HasForeignKey(d => d.IdBetStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BetSportTypeOdds_BetStatus");
            entity.Seed();
        });

        modelBuilder.Entity<BetSportType>(entity =>
        {
            entity.HasKey(e => e.IdBetSportType).HasName("BetSportType_pk");

            entity.ToTable("BetSportType");

            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Seed();
        });

        modelBuilder.Entity<BetStatus>(entity =>
        {
            entity.HasKey(e => e.IdBetStatus).HasName("BetStatus_pk");

            entity.ToTable("BetStatus");

            entity.Property(e => e.Status)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Seed();
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.IdCoupon).HasName("Coupon_pk");

            entity.ToTable("Coupon");

            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        modelBuilder.Entity<CouponOffer>(entity =>
        {
            entity.HasKey(e => new { e.IdCouponOffer, e.IdCoupon, e.IdOffer }).HasName("CouponOffer_pk");

            entity.ToTable("CouponOffer");

            entity.Property(e => e.IdCouponOffer).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdCouponNavigation).WithMany(p => p.CouponOffers)
                .HasForeignKey(d => d.IdCoupon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CouponOffer_Coupon");

            entity.HasOne(d => d.IdOfferNavigation).WithMany(p => p.CouponOffers)
                .HasForeignKey(d => d.IdOffer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CouponOffer_Offer");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.IdOffer).HasName("Offer_pk");

            entity.ToTable("Offer");

            entity.Property(e => e.Description)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.IdPlayer).HasName("Player_pk");

            entity.ToTable("Player");

            entity.Property(e => e.IdPlayer).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdPlayerNavigation).WithOne(p => p.Player)
                .HasForeignKey<Player>(d => d.IdPlayer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Player_User");
        });

        modelBuilder.Entity<PlayerBet>(entity =>
        {
            entity.HasKey(e => new { e.IdPlayerBet, e.IdUser, e.IdCoupon }).HasName("PlayerBet_pk");

            entity.ToTable("PlayerBet");

            entity.Property(e => e.IdPlayerBet).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdCouponNavigation).WithMany(p => p.PlayerBets)
                .HasForeignKey(d => d.IdCoupon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlayerBet_Coupon");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.PlayerBets)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlayerBet_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("User_pk");

            entity.ToTable("User");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.RefreshTokenExpiration).HasColumnType("datetime");
        });
    }
}
