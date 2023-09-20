namespace Sistema_Eventos.Models
{
    public class Ingresso
    {
        public int id { get; set; }
        public float preco { get; set; }
        public Evento ?Evento { get; set; }
    }
}
