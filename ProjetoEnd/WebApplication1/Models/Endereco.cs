using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        internal void Modificar(Endereco endereco)
        {
            Uf = endereco.Uf;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Rua = endereco.Rua;
            Numero = endereco.Numero;
        }
    }
}