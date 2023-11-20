using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
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

        public class LoginRequest
        {
            public string Email { get; set; } = "";
            public string Senha { get; set; } = "";
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Logar([FromBody] LoginRequest Body)
        {
            try
            {
                List<Usuario> usuarios = await _context.Usuario.ToListAsync();

                List<Usuario> usuarioFinal = usuarios.Where(user => user.Email == Body.Email && user.Senha == Body.Senha).ToList();

                Console.WriteLine();
                if (usuarioFinal.Count <= 0)
                {
                    return Ok(new { Message = "Login negado" });
                }
                return Ok(new {Message = "Logado"});
            } catch (Exception ex)
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
            var usuarioTemp = await _context.Usuario.FindAsync(id);

            if (usuarioTemp is null) return NotFound();
            _context.Usuario.Remove(usuarioTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
