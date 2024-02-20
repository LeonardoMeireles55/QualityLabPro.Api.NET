﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QualityLabPro.Api.Data;

#nullable disable

namespace QualityLabPro.Api.Migrations
{
    [DbContext(typeof(GenericAnalyticsContext))]
    partial class GenericAnalyticsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QualityLabPro.Api.GenericAnalytics.GenericAnalytics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LevelLot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Mean")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Sd")
                        .HasColumnType("double precision");

                    b.Property<string>("TestLot")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UnitValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("GenericAnalytics");
                });
#pragma warning restore 612, 618
        }
    }
}