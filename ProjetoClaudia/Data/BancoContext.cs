﻿using Microsoft.EntityFrameworkCore;
using ProjetoClaudia.Models;

namespace ProjetoClaudia.Data
{
    public class BancoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public BancoContext(DbContextOptions<BancoContext> opcoes) : base(opcoes)
        {

        }
    }
}
