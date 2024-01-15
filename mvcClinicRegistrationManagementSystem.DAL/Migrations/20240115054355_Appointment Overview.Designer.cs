﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvcClinicRegistrationManagementSystem.DAL.Context;

#nullable disable

namespace mvcClinicRegistrationManagementSystem.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240115054355_Appointment Overview")]
    partial class AppointmentOverview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Appointment", b =>
                {
                    b.Property<int>("AppoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppoID"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PatientsID")
                        .HasColumnType("int");

                    b.Property<int>("PatientsID1")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationsID")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationsID1")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppoID");

                    b.HasIndex("DoctorId1");

                    b.HasIndex("PatientsID1");

                    b.HasIndex("SpecializationsID1");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Doctor", b =>
                {
                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Patient", b =>
                {
                    b.Property<int>("PatientsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientsID"), 1L, 1);

                    b.Property<int>("ContactDetails")
                        .HasColumnType("int");

                    b.Property<string>("PatientsName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PatientsID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Specialization", b =>
                {
                    b.Property<int>("SpecializationsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecializationsID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SpecializationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SpecializationsID");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Appointment", b =>
                {
                    b.HasOne("mvcClinicRegistrationManagementSystem.DAL.Model.Doctor", "Doctor")
                        .WithMany("Appointment")
                        .HasForeignKey("DoctorId1");

                    b.HasOne("mvcClinicRegistrationManagementSystem.DAL.Model.Patient", "Patient")
                        .WithMany("Appointment")
                        .HasForeignKey("PatientsID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvcClinicRegistrationManagementSystem.DAL.Model.Specialization", "Specialization")
                        .WithMany("Appointments")
                        .HasForeignKey("SpecializationsID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Doctor", b =>
                {
                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Patient", b =>
                {
                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("mvcClinicRegistrationManagementSystem.DAL.Model.Specialization", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}