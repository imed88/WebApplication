﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApps.Models;

namespace WebApps.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200716095141_UpdateNameProperty")]
    partial class UpdateNameProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApps.Models.Admins", b =>
                {
                    b.Property<int>("idAdmin")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("emailAdmin")
                        .IsRequired();

                    b.Property<string>("nameAdmin");

                    b.Property<string>("passwordAdmin")
                        .IsRequired();

                    b.Property<string>("phoneAdmin");

                    b.HasKey("idAdmin");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("WebApps.Models.doctors", b =>
                {
                    b.Property<int>("idDoctors")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("emailDoctors")
                        .IsRequired();

                    b.Property<int?>("gender");

                    b.Property<string>("nameDoctors")
                        .IsRequired();

                    b.Property<string>("phoneDoctors");

                    b.Property<string>("specialist");

                    b.HasKey("idDoctors");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("WebApps.Models.nurses", b =>
                {
                    b.Property<int>("idNurse")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("emailNurse")
                        .IsRequired();

                    b.Property<string>("nameNurse");

                    b.Property<string>("passwordNurse");

                    b.Property<string>("phoneNurse");

                    b.HasKey("idNurse");

                    b.ToTable("nurses");
                });

            modelBuilder.Entity("WebApps.Models.patients", b =>
                {
                    b.Property<int>("idPatients")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int?>("doctor_id");

                    b.Property<int?>("doctorsidDoctors");

                    b.Property<int?>("gender");

                    b.Property<string>("health_condition");

                    b.Property<string>("namePatients");

                    b.Property<int?>("nurse_id");

                    b.Property<int?>("nursesidNurse");

                    b.Property<string>("phonePatients");

                    b.HasKey("idPatients");

                    b.HasIndex("doctorsidDoctors");

                    b.HasIndex("nursesidNurse");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("WebApps.Models.patients", b =>
                {
                    b.HasOne("WebApps.Models.doctors", "doctors")
                        .WithMany("patients")
                        .HasForeignKey("doctorsidDoctors");

                    b.HasOne("WebApps.Models.nurses", "nurses")
                        .WithMany("patients")
                        .HasForeignKey("nursesidNurse");
                });
#pragma warning restore 612, 618
        }
    }
}
