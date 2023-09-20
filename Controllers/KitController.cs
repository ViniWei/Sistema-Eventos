using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Eventos.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KitController : ControllerBase
    {

        SistemaEventosDbContext? _context;

        public KitController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Kit>>> Listar()
        {
            if (_context.Kit is null)
                return NotFound();
            return await _context.Kit.ToListAsync();

        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Kit kit)
        {
            try
            {
                await _context.AddAsync(kit);
                await _context.SaveChangesAsync();
                return Created("", kit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Kit kit)
        {
            _context.Update(kit);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var kitTemp = await _context.Kit.FindAsync(id);

            if (kitTemp is null) return NotFound();
            _context.Kit.Remove(kitTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
