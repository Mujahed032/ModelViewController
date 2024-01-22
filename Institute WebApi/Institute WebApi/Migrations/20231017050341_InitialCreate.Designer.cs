﻿// <auto-generated />
using System;
using Institute_WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Institute_WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231017050341_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Institute_WebApi.Models.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatchId"));

                    b.Property<string>("BatchCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("TimeSlot")
                        .HasColumnType("tinyint");

                    b.HasKey("BatchId");

                    b.HasIndex("CourseId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CoursName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseDuration")
                        .HasColumnType("int");

                    b.Property<int>("CourseFee")
                        .HasColumnType("int");

                    b.Property<string>("Prerequisite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Institute_WebApi.Models.CourseFaculty", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("CourseId", "FacultyId");

                    b.HasIndex("FacultyId");

                    b.ToTable("CourseFaculties");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacultyId"));

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Payment", b =>
                {
                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("PaymentDate", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("JoinDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Institute_WebApi.Models.StudentBatch", b =>
                {
                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("BatchId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentBatches");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Batch", b =>
                {
                    b.HasOne("Institute_WebApi.Models.Course", "Course")
                        .WithMany("Batches")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Institute_WebApi.Models.Faculty", "Faculty")
                        .WithMany("Batches")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Institute_WebApi.Models.CourseFaculty", b =>
                {
                    b.HasOne("Institute_WebApi.Models.Course", "Course")
                        .WithMany("CourseFaculties")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Institute_WebApi.Models.Faculty", "Faculty")
                        .WithMany("CourseFaculties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Payment", b =>
                {
                    b.HasOne("Institute_WebApi.Models.Student", "Student")
                        .WithMany("Payments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Institute_WebApi.Models.StudentBatch", b =>
                {
                    b.HasOne("Institute_WebApi.Models.Batch", "Batch")
                        .WithMany("StudentBatches")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Institute_WebApi.Models.Student", "Student")
                        .WithMany("StudentBatches")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Batch", b =>
                {
                    b.Navigation("StudentBatches");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Course", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("CourseFaculties");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Faculty", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("CourseFaculties");
                });

            modelBuilder.Entity("Institute_WebApi.Models.Student", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("StudentBatches");
                });
#pragma warning restore 612, 618
        }
    }
}