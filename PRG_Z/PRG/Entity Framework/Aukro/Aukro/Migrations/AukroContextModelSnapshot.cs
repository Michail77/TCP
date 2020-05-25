﻿// <auto-generated />
using System;
using Aukro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aukro.Migrations
{
    [DbContext(typeof(AukroContext))]
    partial class AukroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aukro.Models.Auctions", b =>
                {
                    b.Property<int>("AuctionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuyNowPrice")
                        .HasColumnType("int");

                    b.Property<int>("CurrentPrice")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int>("EndTime")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnd")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int>("SellerUserId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerUserId")
                        .HasColumnType("int");

                    b.HasKey("AuctionId");

                    b.HasIndex("SellerUserId");

                    b.HasIndex("WinnerUserId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Aukro.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aukro.Models.Auctions", b =>
                {
                    b.HasOne("Aukro.Models.Users", "SellerUser")
                        .WithMany("AuctionsSellerUser")
                        .HasForeignKey("SellerUserId")
                        .HasConstraintName("FK_Auctions_Users1")
                        .IsRequired();

                    b.HasOne("Aukro.Models.Users", "WinnerUser")
                        .WithMany("AuctionsWinnerUser")
                        .HasForeignKey("WinnerUserId")
                        .HasConstraintName("FK_Auctions_Users");
                });
#pragma warning restore 612, 618
        }
    }
}