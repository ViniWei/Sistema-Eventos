namespace Sistema_Eventos.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Date { get; set; }
        public string? Endereco { get; set; }
        public Organizador? Organizador { get; set; }
    }
}
