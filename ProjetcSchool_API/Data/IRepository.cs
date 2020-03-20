using System.Threading.Tasks;
using ProjetcSchool_API.Models;

namespace ProjetcSchool_API.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveChangesAsync();

         Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);

         Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor);

         Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor);

        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);

         Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno);

    }
}