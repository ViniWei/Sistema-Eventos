namespace Sistema_Eventos.Models
{
    public class Ingresso
    {
        public int Id { get; set; }
        public float? Preco { get; set; }
        public Evento? Evento { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
