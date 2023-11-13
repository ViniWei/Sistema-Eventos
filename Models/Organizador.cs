using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Models
{
    public class Organizador
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
