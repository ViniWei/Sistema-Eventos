namespace Sistema_Eventos.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public DateOnly dataNascimento { get; set; }
        public string cpf { get; set; }
        public List<Plano> planos { get;}
    }
}
