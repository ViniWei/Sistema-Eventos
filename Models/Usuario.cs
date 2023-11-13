﻿using System.ComponentModel.DataAnnotations;

namespace Sistema_Eventos.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public List<Plano>? Planos { get; set;  }
    }
}
