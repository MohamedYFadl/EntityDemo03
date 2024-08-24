﻿// <auto-generated />
using EntityDemo03.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityDemo03.Migrations
{
    [DbContext(typeof(DemoContext))]
    partial class DemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityDemo03.Entities.Vechicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VechicleType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("vechicles");

                    b.HasDiscriminator<string>("VechicleType").HasValue("Vechicle");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityDemo03.Entities.Car", b =>
                {
                    b.HasBaseType("EntityDemo03.Entities.Vechicle");

                    b.Property<int>("DoorsCount")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("C");
                });

            modelBuilder.Entity("EntityDemo03.Entities.Truck", b =>
                {
                    b.HasBaseType("EntityDemo03.Entities.Vechicle");

                    b.Property<int>("LoadCapacity")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("T");
                });
#pragma warning restore 612, 618
        }
    }
}
