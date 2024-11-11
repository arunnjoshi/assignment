﻿// <auto-generated />
using System;
using EmployCheck.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployCheck.Application.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("EmployCheck.Application.Models.Employment", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEmploymentVerified")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("VerifiedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employment", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}