using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Models
{
    public class Kit
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public float? Preco { get; set; }
        public int? OrganizadorId { get; set; }
        public Organizador? Organizador { get; set; }
        public List<Produto>? Produtos { get; set; } 
    }
}
