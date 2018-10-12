﻿// <auto-generated />
using System;
using GymTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymTest.Migrations
{
    [DbContext(typeof(GymTestContext))]
    [Migration("20181012134000_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("GymTest.Models.Assistance", b =>
                {
                    b.Property<int>("AssistanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AssistanceDate");

                    b.Property<int>("UserId");

                    b.HasKey("AssistanceId");

                    b.HasIndex("UserId");

                    b.ToTable("Assistance");
                });

            modelBuilder.Entity("GymTest.Models.CashCategory", b =>
                {
                    b.Property<int>("CashCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CashCategoryDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CashCategoryId");

                    b.ToTable("CashCategory");
                });

            modelBuilder.Entity("GymTest.Models.CashMovement", b =>
                {
                    b.Property<int>("CashMovementId")
                        .ValueGeneratedOnAdd();

                    b.Property<float?>("Amount")
                        .IsRequired();

                    b.Property<int>("CashCategoryId");

                    b.Property<string>("CashMovementDetails")
                        .HasMaxLength(200);

                    b.Property<int>("CashMovementTypeId");

                    b.HasKey("CashMovementId");

                    b.HasIndex("CashCategoryId");

                    b.HasIndex("CashMovementTypeId");

                    b.ToTable("CashMovement");
                });

            modelBuilder.Entity("GymTest.Models.CashMovementType", b =>
                {
                    b.Property<int>("CashMovementTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CashMovementTypeDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CashMovementTypeId");

                    b.ToTable("CashMovementType");
                });

            modelBuilder.Entity("GymTest.Models.MovementType", b =>
                {
                    b.Property<int>("MovementTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("MovementTypeId");

                    b.ToTable("MovementType");
                });

            modelBuilder.Entity("GymTest.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<float?>("Amount")
                        .IsRequired();

                    b.Property<int>("MovementTypeId");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<int>("QuantityMovmentType");

                    b.Property<int>("UserId");

                    b.HasKey("PaymentId");

                    b.HasIndex("MovementTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("GymTest.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Commentaries")
                        .HasMaxLength(200);

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phones")
                        .HasMaxLength(200);

                    b.Property<DateTime>("SignInDate");

                    b.Property<string>("Token")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GymTest.Models.Assistance", b =>
                {
                    b.HasOne("GymTest.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GymTest.Models.CashMovement", b =>
                {
                    b.HasOne("GymTest.Models.CashCategory", "CashCategory")
                        .WithMany()
                        .HasForeignKey("CashCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GymTest.Models.CashMovementType", "CashMovementType")
                        .WithMany()
                        .HasForeignKey("CashMovementTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GymTest.Models.Payment", b =>
                {
                    b.HasOne("GymTest.Models.MovementType", "MovmentType")
                        .WithMany()
                        .HasForeignKey("MovementTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GymTest.Models.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
