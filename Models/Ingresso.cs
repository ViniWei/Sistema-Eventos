using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Models
{
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }
        public float? Preco { get; set; }
        public int? EventoId { get; set; }
        public Evento? Evento { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
} 