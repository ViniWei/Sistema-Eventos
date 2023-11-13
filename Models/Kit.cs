﻿namespace Sistema_Eventos.Models
{
    public class Kit
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public float? Preco { get; set; }
        public Organizador? Organizador { get; set; }
        public List<Produto>? Produtos { get; set; } 
    }
}
