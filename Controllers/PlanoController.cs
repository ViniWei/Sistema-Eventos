using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlanoController : ControllerBase
    {
        SistemaEventosDbContext? _context;

        public PlanoController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Plano>>> Listar()
        {
            if (_context.Plano is null)
                return NotFound();
            return await _context.Plano.ToListAsync();

        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Plano plano)
        {
            try
            {
                await _context.AddAsync(plano);
                await _context.SaveChangesAsync();
                return Created("", plano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Plano plano)
        {
            _context.Update(plano);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var planoTemp = await _context.Plano.FindAsync(id);

            if (planoTemp is null) return NotFound();
            _context.Plano.Remove(planoTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
