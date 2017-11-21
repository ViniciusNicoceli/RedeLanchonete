using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Produto
    {
        public Produto()
        {
        }
        public int ProdutoId { get; set; }
        [Required,StringLength(20)]
        public string  Nome { get; set; }
        [Required,Range(0.0,10000.0)]
        public float Preco { get; set; }
        public int RestauranteId { get; set; }
        public string Descricao { get; set; }



        public void Modificar(Produto produtoNovo)
        {
            Nome = produtoNovo.Nome;
            Preco = produtoNovo.Preco;
        }
    }
}