﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetcSchool_API.Data;

namespace ProjetcSchool_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("ProjetcSchool_API.Models.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SobreNome")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            DataNascimento = "26/03/2009",
                            Nome = "João",
                            ProfessorId = 1,
                            SobreNome = "Margotto"
                        },
                        new
                        {
                            id = 2,
                            DataNascimento = "16/11/2009",
                            Nome = "Pedro",
                            ProfessorId = 2,
                            SobreNome = "Margotto"
                        },
                        new
                        {
                            id = 3,
                            DataNascimento = "16/12/2016",
                            Nome = "Joaquim",
                            ProfessorId = 1,
                            SobreNome = "Margotto"
                        });
                });

            modelBuilder.Entity("ProjetcSchool_API.Models.Professor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Nome = "Ligia"
                        },
                        new
                        {
                            id = 2,
                            Nome = "Andre"
                        });
                });

            modelBuilder.Entity("ProjetcSchool_API.Models.Aluno", b =>
                {
                    b.HasOne("ProjetcSchool_API.Models.Professor", "professor")
                        .WithMany("alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
