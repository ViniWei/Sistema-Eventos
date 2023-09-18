using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;

namespace Sistema_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtuanteController : ControllerBase
    {
        SistemaEventosDbContext? _context;

        public AtuanteController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Atuante>>> Listar()
        {
            if (_context.Atuante is null)
                return NotFound();
            return await _context.Atuante.ToListAsync();
            
        }

        [HttpPost]
        [Route("Insirir")]
        public IActionResult Insirir(Atuante atuante)
        {
            try
            {
                _context.Add(atuante);
                _context.SaveChanges();
                return Created("", atuante);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    
    }
}
