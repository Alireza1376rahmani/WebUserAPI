﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfraStructure.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20211012081109_i")]
    partial class i
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Principal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Principal");
                });

            modelBuilder.Entity("GroupPrincipal", b =>
                {
                    b.Property<Guid>("GroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MembersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("GroupPrincipal");
                });

            modelBuilder.Entity("Domain.Group", b =>
                {
                    b.HasBaseType("Domain.Principal");

                    b.HasDiscriminator().HasValue("Group");
                });

            modelBuilder.Entity("GroupPrincipal", b =>
                {
                    b.HasOne("Domain.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Principal", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
