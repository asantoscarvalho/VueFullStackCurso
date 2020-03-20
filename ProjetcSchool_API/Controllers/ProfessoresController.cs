using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetcSchool_API.Data;
using ProjetcSchool_API.Models;

namespace ProjetcSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : Controller
    {
        public IRepository _repo {get;}
        public ProfessoresController(IRepository repo)
        {
            _repo = repo;
        } 
        
   [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
              _repo.Add(model);
              if  (await _repo.SaveChangesAsync())
              {
                    return Created($"/api/professores/{model.id}",model);    
              }  
              
            }
            catch (System.Exception)
            {
                
              return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no Banco");
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProfessoresAsync(true);
                return Ok(result);   
            }
            catch (System.Exception)
            {
                
              return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no Banco");
            }
        }
        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorID, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(ProfessorID, false);
                if (professor == null) return NotFound();

                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetProfessorAsyncById(ProfessorID, true);
                    return Created($"/api/professores/{model.id}", model);
                }   
            }
            catch (System.Exception)
            {
                
              return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no Banco");
            }

            return BadRequest();
        }
        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int ProfessorId)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
                if (professor == null) return NotFound();

                _repo.Delete(professor);
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
        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> Get(int ProfessorId)
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