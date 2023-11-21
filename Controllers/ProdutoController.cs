using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            try
            {

                _context.Update(produto);
                await _context.SaveChangesAsync();
                return Ok();

            } catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }

        [HttpPatch]
        [Route("patch/{id}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Dictionary<string, object> patch)
        {
            var produtoTemp = await _context.Produto.FindAsync(id);

            if (produtoTemp is null) return NotFound();

            foreach (var campo in patch)
            {
                switch (campo.Key)
                {
                    case "nome":

                        produtoTemp.Nome = campo.Value.ToString();
                        break;

                    case "descricao":

                        produtoTemp.Descricao = campo.Value.ToString();
                        break;

                    case "preco":

                        if (int.TryParse(campo.Value.ToString(), out int novoPreco))
                        {
                            produtoTemp.Preco = novoPreco;
                        }
                        else
                        {
                            return BadRequest("O preço deve ser um número válido.");
                        }
                        break;

                    default:
                        return BadRequest($"Campo '{campo.Key}' não é suportado.");
                }
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            Console.WriteLine(id);
            var produtoTemp = await _context.Produto.FindAsync(id);

            if (produtoTemp is null) return NotFound();
            _context.Produto.Remove(produtoTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
