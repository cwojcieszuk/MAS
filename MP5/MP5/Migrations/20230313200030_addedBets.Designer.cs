﻿// <auto-generated />
using System;
using MP5.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MP5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230313200030_addedBets")]
    partial class addedBets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MP5.Models.Bet", b =>
                {
                    b.Property<int>("IdBet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBet"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CouponIdCoupon")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("IdBet");

                    b.HasIndex("CouponIdCoupon");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("MP5.Models.BetEvents", b =>
                {
                    b.Property<int>("IdBetEvents")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBetEvents"), 1L, 1);

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdBet")
                        .HasColumnType("int");

                    b.HasKey("IdBetEvents");

                    b.HasIndex("IdBet")
                        .IsUnique();

                    b.ToTable("BetEvents");
                });

            modelBuilder.Entity("MP5.Models.BetSports", b =>
                {
                    b.Property<int>("IdBetSports")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBetSports"), 1L, 1);

                    b.Property<int>("IdBet")
                        .HasColumnType("int");

                    b.Property<string>("SportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBetSports");

                    b.HasIndex("IdBet")
                        .IsUnique();

                    b.ToTable("BetSports");
                });

            modelBuilder.Entity("MP5.Models.Coupon", b =>
                {
                    b.Property<int>("IdCoupon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCoupon"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCoupon");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("MP5.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlayer"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("IdPlayer");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            IdPlayer = 1,
                            Age = 0,
                            BirthDate = new DateTime(1984, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jan@gmail.com",
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            PhoneNumber = 123456789
                        });
                });

            modelBuilder.Entity("MP5.Models.PlayerCoupon", b =>
                {
                    b.Property<int>("IdPlayer")
                        .HasColumnType("int");

                    b.Property<int>("IdCoupon")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("IdPlayer", "IdCoupon");

                    b.HasIndex("IdCoupon");

                    b.ToTable("PlayerCoupons");
                });

            modelBuilder.Entity("MP5.Models.Bet", b =>
                {
                    b.HasOne("MP5.Models.Coupon", null)
                        .WithMany("Bets")
                        .HasForeignKey("CouponIdCoupon");
                });

            modelBuilder.Entity("MP5.Models.BetEvents", b =>
                {
                    b.HasOne("MP5.Models.Bet", "Bet")
                        .WithOne("BetEvents")
                        .HasForeignKey("MP5.Models.BetEvents", "IdBet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("MP5.Models.BetSports", b =>
                {
                    b.HasOne("MP5.Models.Bet", "Bet")
                        .WithOne("BetSports")
                        .HasForeignKey("MP5.Models.BetSports", "IdBet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("MP5.Models.PlayerCoupon", b =>
                {
                    b.HasOne("MP5.Models.Coupon", "Coupon")
                        .WithMany("PlayerCoupons")
                        .HasForeignKey("IdCoupon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MP5.Models.Player", "Player")
                        .WithMany("PlayerCoupons")
                        .HasForeignKey("IdPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coupon");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MP5.Models.Bet", b =>
                {
                    b.Navigation("BetEvents");

                    b.Navigation("BetSports");
                });

            modelBuilder.Entity("MP5.Models.Coupon", b =>
                {
                    b.Navigation("Bets");

                    b.Navigation("PlayerCoupons");
                });

            modelBuilder.Entity("MP5.Models.Player", b =>
                {
                    b.Navigation("PlayerCoupons");
                });
#pragma warning restore 612, 618
        }
    }
}
