using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Restaurante
    {
        public Restaurante()
        {
            Produtos = new HashSet<Produto>();
            Telefone = new Telefone();
            Endereco = new Endereco();
        }
        [Key]
        public int RestauranteId { get; set; }

        [ForeignKey("Telefone")]
        public int TelefoneId { get; set; }

        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }



        public string Nome { get; set; }
        public virtual Telefone Telefone { get; set; }
        public virtual Endereco Endereco { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        
        internal void Modificar(Restaurante restaurante)
        {
            Nome = restaurante.Nome;
        }



        //public virtual Usuario Usuario { get; set; }


    }
}