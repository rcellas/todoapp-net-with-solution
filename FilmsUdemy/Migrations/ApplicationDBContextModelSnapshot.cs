﻿// <auto-generated />
using System;
using FilmsUdemy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmsUdemy.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FilmsUdemy.Entity.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Photo")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.ActorFilm", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ActorFilms");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Error", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Poster")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.GendersFilms", b =>
                {
                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("GenderId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("GendersFilms");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.ActorFilm", b =>
                {
                    b.HasOne("FilmsUdemy.Entity.Actor", "Actor")
                        .WithMany("ActorFilms")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmsUdemy.Entity.Film", "Film")
                        .WithMany("ActorFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Comment", b =>
                {
                    b.HasOne("FilmsUdemy.Entity.Film", null)
                        .WithMany("Comments")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmsUdemy.Entity.GendersFilms", b =>
                {
                    b.HasOne("FilmsUdemy.Entity.Film", "Film")
                        .WithMany("GendersFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmsUdemy.Entity.Gender", "Gender")
                        .WithMany("GendersFilms")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Actor", b =>
                {
                    b.Navigation("ActorFilms");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Film", b =>
                {
                    b.Navigation("ActorFilms");

                    b.Navigation("Comments");

                    b.Navigation("GendersFilms");
                });

            modelBuilder.Entity("FilmsUdemy.Entity.Gender", b =>
                {
                    b.Navigation("GendersFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
