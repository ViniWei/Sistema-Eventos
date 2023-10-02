using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Eventos.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IngressoController : ControllerBase
    {

        SistemaEventosDbContext? _context;

        public IngressoController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Ingresso>>> Listar()
        {
            if (_context.Ingresso is null)
                return NotFound();
            return await _context.Ingresso.ToListAsync();

        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Ingresso ingresso)
        {
            try
            {
                await _context.AddAsync(ingresso);
                await _context.SaveChangesAsync();
                return Created("", ingresso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Ingresso ingresso)
        {
            _context.Update(ingresso);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var ingressoTemp = await _context.Ingresso.FindAsync(id);

            if (ingressoTemp is null) return NotFound();
            _context.Ingresso.Remove(ingressoTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
