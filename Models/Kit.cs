namespace Sistema_Eventos.Models
{
    public class Kit
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public float preco { get; set; }
        public List<Produto> produtos { get; set; } = new();
    }
}
