using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController :  ControllerBase
    {

        SistemaEventosDbContext? _context;

        public UsuarioController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Listar()
        {
            if (_context.Usuario is null)
                return NotFound();
            return await _context.Usuario.ToListAsync();

        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Usuario usuario)
        {
            try
            {
                await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return Created("", usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var usuarioTemp = await _context.Kit.FindAsync(id);

            if (usuarioTemp is null) return NotFound();
            _context.Kit.Remove(usuarioTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
