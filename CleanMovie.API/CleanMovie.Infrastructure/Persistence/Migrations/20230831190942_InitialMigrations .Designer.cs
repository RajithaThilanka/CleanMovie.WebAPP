﻿// <auto-generated />
using System;
using CleanMovie.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanMovie.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20230831190942_InitialMigrations ")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanMovie.Domain.Member", b =>
                {
                    b.Property<int>("memberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("memberId"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("rentalId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("memberId");

                    b.HasIndex("rentalId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CleanMovie.Domain.Movie", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("movieId"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("movieDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("movieName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("moviePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("rentalDuration")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("movieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CleanMovie.Domain.MovieRental", b =>
                {
                    b.Property<int>("rentalId")
                        .HasColumnType("integer");

                    b.Property<int>("movieId")
                        .HasColumnType("integer");

                    b.HasKey("rentalId", "movieId");

                    b.HasIndex("movieId");

                    b.ToTable("MovieRentals");
                });

            modelBuilder.Entity("CleanMovie.Domain.Rental", b =>
                {
                    b.Property<int>("rentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("rentalId"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("rentalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("rentalExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("rentalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("rentalId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("CleanMovie.Domain.Member", b =>
                {
                    b.HasOne("CleanMovie.Domain.Rental", "Rental")
                        .WithMany("Members")
                        .HasForeignKey("rentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("CleanMovie.Domain.MovieRental", b =>
                {
                    b.HasOne("CleanMovie.Domain.Movie", null)
                        .WithMany("movieRentals")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanMovie.Domain.Rental", null)
                        .WithMany("movieRentals")
                        .HasForeignKey("rentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanMovie.Domain.Movie", b =>
                {
                    b.Navigation("movieRentals");
                });

            modelBuilder.Entity("CleanMovie.Domain.Rental", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("movieRentals");
                });
#pragma warning restore 612, 618
        }
    }
}
