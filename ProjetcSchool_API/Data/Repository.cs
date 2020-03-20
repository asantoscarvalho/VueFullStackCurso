using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetcSchool_API.Models;

namespace ProjetcSchool_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context {get;}
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(p => p.professor);
            }

            query = query.AsNoTracking().OrderBy(p => p.id);

            return await query.ToArrayAsync();

        }

        public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(p => p.professor);
            }

            query = query.AsNoTracking().Where(p => p.id == AlunoId).OrderBy(p => p.id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(p => p.professor);
            }

            query = query.AsNoTracking().Where(p => p.ProfessorId == ProfessorId).OrderBy(p => p.id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.alunos);
            }

            query = query.AsNoTracking().OrderBy(p => p.id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.alunos);
            }

            query = query.AsNoTracking().Where(p => p.id == ProfessorId).OrderBy(p => p.id);

            return await query.FirstOrDefaultAsync();
        }
    }
}