using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Atuante atuante)
        {
            try
            {
                await _context.AddAsync(atuante);
                await _context.SaveChangesAsync();
                return Created("", atuante);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Atuante atuante)
        {
            _context.Update(atuante);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var atuanteTemp = await _context.Atuante.FindAsync(id);

            if (atuanteTemp is null) return NotFound();
            _context.Atuante.Remove(atuanteTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
