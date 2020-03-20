
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetcSchool_API.Models;

namespace ProjetcSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Aluno> Alunos {get; set;}
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
              .HasData(
                  new List<Professor>(){ 

                      new Professor(){
                          id = 1,
                          Nome = "Ligia"
                      },
                      new Professor(){
                          id = 2,
                          Nome = "Andre"
                      }

                  }
              );

            builder.Entity<Aluno>()
              .HasData(
                  new List<Aluno>(){ 

                      new Aluno(){
                          id = 1,
                          Nome = "João",
                          SobreNome = "Margotto",
                          DataNascimento = "26/03/2009",
                          ProfessorId = 1
                      },
                      new Aluno(){
                          id = 2,
                          Nome = "Pedro",
                          SobreNome = "Margotto",
                          DataNascimento = "16/11/2009",
                          ProfessorId = 2
                      },
                      new Aluno(){
                          id = 3,
                          Nome = "Joaquim",
                          SobreNome = "Margotto",
                          DataNascimento = "16/12/2016",
                          ProfessorId = 1
                      }


                  }
              );
        }
    }
}