﻿// <auto-generated />
using CV_storage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CV_storage.Data.Migrations
{
    [DbContext(typeof(CvDbContext))]
    partial class CvDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

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
                    b.Navigation("LanguageKnowledges");
                });
#pragma warning restore 612, 618
        }
    }
}
