using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Models
{
    public class Atuante
    {
        [Key]
        public int Id { get; set; }
        public string? Nome  { get; set; }
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }
    }
}
