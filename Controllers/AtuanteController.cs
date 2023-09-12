using Microsoft.AspNetCore.Mvc;
using Sistema_Eventos.Models;
using Sistema_Eventos.Data;


namespace Sistema_Eventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtuanteController : ControllerBase
    {
        [HttpPost]
        [Route("Insirir")]
        public IActionResult insirir(Atuante atuante)
        {
            try
            {
                return Created("", atuante);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult listar()
        {
            return null;
        }
    }
}
