﻿// <auto-generated />
using System;
using Costumer_Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Costumer_Loan.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231113222437_secondMigration")]
    partial class secondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Costumer_Loan.Entities.Costumer", b =>
                {
                    b.Property<int?>("CostumerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CostumerId"));

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CostumerId");

                    b.ToTable("Costumers");
                });

            modelBuilder.Entity("Costumer_Loan.Entities.Loan", b =>
                {
                    b.Property<int?>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LoanId"));

                    b.Property<int?>("Amount")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("CostumerId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("LoanId");

                    b.HasIndex("CostumerId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Costumer_Loan.Entities.Loan", b =>
                {
                    b.HasOne("Costumer_Loan.Entities.Costumer", "Costumer")
                        .WithMany("Loans")
                        .HasForeignKey("CostumerId");

                    b.Navigation("Costumer");
                });

            modelBuilder.Entity("Costumer_Loan.Entities.Costumer", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}