namespace Sistema_Eventos.Models
{
    public class Produto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public float? Preco { get; set; }
        public Organizador? Organizador { get; set; }
        public List<Kit>? Kits { get; set; }
    }
}
