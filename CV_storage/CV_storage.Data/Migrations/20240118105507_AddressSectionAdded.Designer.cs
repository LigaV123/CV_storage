﻿// <auto-generated />
using CV_storage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CV_storage.Data.Migrations
{
    [DbContext(typeof(CvDbContext))]
    [Migration("20240118105507_AddressSectionAdded")]
    partial class AddressSectionAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("CV_storage.Core.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("House")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(1024)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CV_storage.Core.Models.CurriculumVitae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CurriculumVitae");
                });

            modelBuilder.Entity("CV_storage.Core.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Degree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("EducationEndDate")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int>("EducationForm")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EducationStartDate")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("EducationalEstablishment")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Faculty")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("CV_storage.Core.Models.LanguageKnowledge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<int>("LanguageLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumVitaeId");

                    b.ToTable("LanguageKnowledge");
                });

            modelBuilder.Entity("CV_storage.Core.Models.Address", b =>
                {
                    b.HasOne("CV_storage.Core.Models.CurriculumVitae", "CurriculumVitae")
                        .WithOne("MainAddress")
                        .HasForeignKey("CV_storage.Core.Models.Address", "CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CV_storage.Core.Models.Education", b =>
                {
                    b.HasOne("CV_storage.Core.Models.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Educations")
                        .HasForeignKey("CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CV_storage.Core.Models.LanguageKnowledge", b =>
                {
                    b.HasOne("CV_storage.Core.Models.CurriculumVitae", "CurriculumVitae")
                        .WithMany("LanguageKnowledges")
                        .HasForeignKey("CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("CV_storage.Core.Models.CurriculumVitae", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("LanguageKnowledges");

                    b.Navigation("MainAddress");
                });
#pragma warning restore 612, 618
        }
    }
}