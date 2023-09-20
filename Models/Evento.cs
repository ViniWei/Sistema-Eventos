﻿namespace Sistema_Eventos.Models
{
    public class Evento
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public List<Plano> planos { get; set; }
        public List<Produto> produtos { get; set; }
        public List<Kit> kits { get; set; }
    }
}