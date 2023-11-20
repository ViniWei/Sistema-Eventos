using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public class LoginOrganizadorRequest
        {
            public string Email { get; set; } = "";
            public string Senha { get; set; } = "";
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Logar([FromBody] LoginOrganizadorRequest Body)
        {
            try
            {
                if (_context.Organizador is null) return NotFound();
                List<Organizador> organizadores = await _context.Organizador.ToListAsync();

                List<Organizador> usuarioFinal = organizadores.Where(org => org.Email == Body.Email && org.Senha == Body.Senha).ToList();

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

        [HttpPost]
        [Route("Inserir")]
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
