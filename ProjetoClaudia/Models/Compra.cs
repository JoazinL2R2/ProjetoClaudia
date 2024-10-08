﻿namespace ProjetoClaudia.Models
{
    public class Compra
    {
        public Compra(int id, DateTime dataCompra, string valor)
        {
            Id = id;
            DataCompra = dataCompra;
            Valor = valor;
        }
        public Compra()
        {
            
        }
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string Valor { get; set; }

        public Usuario Usuario { get; set; } = new Usuario();
        public Produto Produto { get; set; } = new Produto();
    }
}
