namespace Sistema_Eventos.Models
{
    public class Atuante
    {
        public int Id { get; set; }
        public string? Nome  { get; set; }
        public Evento? Evento { get; set; }
    }
}
