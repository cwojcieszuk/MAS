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
    [Migration("20230313230409_quickFix")]
    partial class quickFix
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

                    b.Property<string>("BetType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<string>("SportName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBet");

                    b.ToTable("Bets");

                    b.HasDiscriminator<string>("BetType");
                });

            modelBuilder.Entity("MP5.Models.BetCoupon", b =>
                {
                    b.Property<int>("IdBet")
                        .HasColumnType("int");

                    b.Property<int>("IdCoupon")
                        .HasColumnType("int");

                    b.HasKey("IdBet", "IdCoupon");

                    b.HasIndex("IdCoupon");

                    b.ToTable("BetCoupons");
                });

            modelBuilder.Entity("MP5.Models.Coupon", b =>
                {
                    b.Property<int>("IdCoupon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCoupon"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("FullRate")
                        .HasColumnType("float");

                    b.Property<double>("PotentialWin")
                        .HasColumnType("float");

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

            modelBuilder.Entity("MP5.Models.BetCoupon", b =>
                {
                    b.HasOne("MP5.Models.Bet", "Bet")
                        .WithMany("BetCoupons")
                        .HasForeignKey("IdBet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MP5.Models.Coupon", "Coupon")
                        .WithMany("BetCoupons")
                        .HasForeignKey("IdCoupon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");

                    b.Navigation("Coupon");
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
                    b.Navigation("BetCoupons");
                });

            modelBuilder.Entity("MP5.Models.Coupon", b =>
                {
                    b.Navigation("BetCoupons");

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