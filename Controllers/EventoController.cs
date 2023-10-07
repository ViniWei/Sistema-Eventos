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
    public class EventoController : ControllerBase
    {

        SistemaEventosDbContext? _context;

        public EventoController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Evento>>> Listar()
        {
            if (_context.Evento is null)
                return NotFound();
            return await _context.Evento.ToListAsync();

        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Evento evento)
        {
            try
            {
                await _context.AddAsync(evento);
                await _context.SaveChangesAsync();
                return Created("", evento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Evento evento)
        {
            _context.Update(evento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var eventoTemp = await _context.Evento.FindAsync(id);

            if (eventoTemp is null) return NotFound();
            _context.Evento.Remove(eventoTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
