﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalChatApplication.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinimalChatApplication.Migrations
{
    [DbContext(typeof(EFDataContext))]
    [Migration("20230710055438_AddedRequestLoggingMiddleware")]
    partial class AddedRequestLoggingMiddleware
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("MinimalChatApplication.Model.RequestLogging", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("id"));

                    b.Property<string>("iPOfCaller")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("queryString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("requestBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("timeOfCall")
                        .HasColumnType("bigint");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("requestLoggingMiddleware");
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
