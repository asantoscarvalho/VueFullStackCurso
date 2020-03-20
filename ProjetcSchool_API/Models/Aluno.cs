namespace ProjetcSchool_API.Models
{
    public class Aluno
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string DataNascimento {get; set;}

        public int ProfessorId { get; set; }

        public Professor professor { get; set; }
        
    }
}