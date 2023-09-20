using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Controllers
{
    public class ProdutoController : ControllerBase
    {

        SistemaEventosDbContext? _context;

        public ProdutoController(SistemaEventosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<Produto>>> Listar()
        {
            if (_context.Produto is null)
                return NotFound();
            return await _context.Produto.ToListAsync();

        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Insirir(Produto produto)
        {
            try
            {
                await _context.AddAsync(produto);
                await _context.SaveChangesAsync();
                return Created("", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var produtoTemp = await _context.Produto.FindAsync(id);

            if (produtoTemp is null) return NotFound();
            _context.Produto.Remove(produtoTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
