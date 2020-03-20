using System.Collections.Generic;

namespace ProjetcSchool_API.Models
{
    public class Professor
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> alunos {get; set;}
    }
}