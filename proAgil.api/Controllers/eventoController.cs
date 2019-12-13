using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proAgil.Domain;
using proAgil.Repository;

namespace proAgil.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class eventoController : ControllerBase
    {   
        public readonly IproAgilRepository _repo;
        public eventoController(IproAgilRepository repo)
        {
            this._repo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllEventosAsync(true);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou, erro:{ex.Message}");
            }
            
        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repo.GetEventoAsyncById(EventoId, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            
        }
        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await _repo.GetAllEventosAsyncByTema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"api/evento/{model.Id}", model); 
                }
            }
            catch (System.Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados, erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int EventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(EventoId, false);
                if(evento == null) return NotFound();
                
                _repo.Update(model);
                if(await _repo.SaveChangesAsync())
                {   
                    return Created($"api/evento/{model.Id}",model); 
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados!");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int EventoId)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(EventoId, false);
                if(evento == null) return NotFound();
                
                _repo.Delete(evento);
                if(await _repo.SaveChangesAsync())
                {
                    return Ok(); 
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados!");
            }
            return BadRequest();
        }
    }
    
}