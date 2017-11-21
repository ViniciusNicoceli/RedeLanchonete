using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.DAO
{
    public class RedeComercialContext : DbContext
    {
        public RedeComercialContext() : base("Server=(localdb)\\mssqllocaldb;Database=RedeSocialDeLanchonetes;Trusted_Connection=true;") { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }

        public DbSet<Favorito> Favoritos { get; set; }

        public DbSet<Sugestoes> Sugestoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

}