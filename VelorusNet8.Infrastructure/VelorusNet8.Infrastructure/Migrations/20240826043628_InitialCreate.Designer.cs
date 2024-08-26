﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VelorusNet8.Infrastructure.Data;

#nullable disable

namespace VelorusNet8.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240826043628_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VelorusNet8.Domain.Entities.Aggregates.Branchs.BranchEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CommissionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CommissionRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DefaultShrinkageRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAutomationIntegrationEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHeadOffice")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSalesEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            BranchCode = "B001",
                            BranchName = "Main Branch",
                            CommissionAmount = 1000m,
                            CommissionRate = 0.05m,
                            DefaultShrinkageRate = 0.02m,
                            Email = "mainbranch@example.com",
                            Fax = "555-5678",
                            IsActive = true,
                            IsAutomationIntegrationEnabled = true,
                            IsHeadOffice = true,
                            IsSalesEnabled = true,
                            Phone = "555-1234"
                        });
                });

            modelBuilder.Entity("VelorusNet8.Domain.Entities.Aggregates.Users.UserAccount", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserAccounts");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedDate = new DateTime(2024, 8, 26, 7, 36, 28, 386, DateTimeKind.Local).AddTicks(194),
                            Email = "admin@example.com",
                            IsActive = true,
                            PasswordHash = "hashedpassword",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("VelorusNet8.Domain.Entities.Aggregates.Users.UserBranch", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BranchId");

                    b.HasIndex("BranchId");

                    b.ToTable("UserBranches");
                });

            modelBuilder.Entity("VelorusNet8.Infrastructure.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Request")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("VelorusNet8.Domain.Entities.Aggregates.Users.UserBranch", b =>
                {
                    b.HasOne("VelorusNet8.Domain.Entities.Aggregates.Branchs.BranchEntity", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VelorusNet8.Domain.Entities.Aggregates.Users.UserAccount", "UserAccount")
                        .WithMany("UserBranches")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("VelorusNet8.Domain.Entities.Aggregates.Users.UserAccount", b =>
                {
                    b.Navigation("UserBranches");
                });
#pragma warning restore 612, 618
        }
    }
}
