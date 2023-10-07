using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Sistema_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalController : ControllerBase
    {


        SistemaEventosDbContext? _context;

        public LocalController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Local>>> Listar()
        {
            if (_context.Local is null)
                return NotFound();
            return await _context.Local.ToListAsync();

        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Local local)
        {
            try
            {
                await _context.AddAsync(local);
                await _context.SaveChangesAsync();
                return Created("", local);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Local local)
        {
            _context.Update(local);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var localTemp = await _context.Local.FindAsync(id);

            if (localTemp is null) return NotFound();
            _context.Local.Remove(localTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
