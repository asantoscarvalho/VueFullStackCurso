using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetcSchool_API.Data;
using ProjetcSchool_API.Models;

namespace ProjetcSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : Controller
    {
        public IRepository _repo { get; }
        public AlunosController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/alunos/{model.id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco");
            }
        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int AlunoId)
        {
            try
            {
                var result = await _repo.GetAlunoAsyncById(AlunoId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco");
            }
        }


        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> Put(int AlunoId, Aluno model)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(AlunoId, false);
                if (aluno == null) return NotFound();

                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    aluno = await _repo.GetAlunoAsyncById(AlunoId, true);
                    return Created($"/api/alunos/{model.id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco");
            }
            return BadRequest();
        }
        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> Delete(int AlunoId)
        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(AlunoId, false);
                if (aluno == null) return NotFound();

                _repo.Delete(aluno);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco");
            }
            return BadRequest();
        }
        [HttpGet("ByProfessor/{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorID(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncByProfessorId(ProfessorId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no Banco");
            }
        }
    }
}