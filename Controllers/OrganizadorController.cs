using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Controllers
{
    public class OrganizadorController : ControllerBase
    {

        SistemaEventosDbContext? _context;

        public OrganizadorController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Organizador>>> Listar()
        {
            if (_context.Organizador is null)
                return NotFound();
            return await _context.Organizador.ToListAsync();

        }

        [HttpPost]
        [Route("Insirir")]
        public async Task<IActionResult> Insirir(Organizador organizador)
        {
            try
            {
                await _context.AddAsync(organizador);
                await _context.SaveChangesAsync();
                return Created("", organizador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Organizador organizador)
        {
            _context.Update(organizador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var organizadorTemp = await _context.Organizador.FindAsync(id);

            if (organizadorTemp is null) return NotFound();
            _context.Organizador.Remove(organizadorTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
