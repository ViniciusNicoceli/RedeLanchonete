using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UsuarioMestre
    {
        public int UsuarioMestreId { get; set; }
        public int TelefoneId { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}