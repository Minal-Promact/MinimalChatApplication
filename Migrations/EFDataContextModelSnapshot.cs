﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalChatApplication.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinimalChatApplication.Migrations
{
    [DbContext(typeof(EFDataContext))]
    partial class EFDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("MinimalChatApplication.Model.Message", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("receiverId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("senderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("message");
                });

            modelBuilder.Entity("MinimalChatApplication.Model.User", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("user");
                });
#pragma warning restore 612, 618
        }
    }
}