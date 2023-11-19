using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Date { get; set; }
        public string? Endereco { get; set; }
        public int? OrganizadorId { get; set; }
        public int? IngressosDisponiveis { get; set; }
        public Organizador? Organizador { get; set; }
    }
}
