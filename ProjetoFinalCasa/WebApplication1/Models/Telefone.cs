using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Telefone
    {
        [Key]
        public int TelefoneId { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }

        internal void Modificar(Telefone telefone)
        {
            Numero = telefone.Numero;
            Descricao = telefone.Descricao;
        }
    }
}