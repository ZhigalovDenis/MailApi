﻿// <auto-generated />
using System;
using Mail.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mail.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230704212201_CreateDB")]
    partial class CreateDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mail.DAL.Entities.Letter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Recipients")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("Mail.DAL.Entities.LetterStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FailedMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LetterStatuses");
                });

            modelBuilder.Entity("Mail.DAL.Entities.LetterStatus", b =>
                {
                    b.HasOne("Mail.DAL.Entities.Letter", "Letter")
                        .WithOne("LetterStatus")
                        .HasForeignKey("Mail.DAL.Entities.LetterStatus", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Letter");
                });

            modelBuilder.Entity("Mail.DAL.Entities.Letter", b =>
                {
                    b.Navigation("LetterStatus")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}