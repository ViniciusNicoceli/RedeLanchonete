using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.DAO;

namespace WebApplication1.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Telefone = new Telefone();
            Endereco = new Endereco();
        }

        [Key]
        public int UsuarioId { get; set; }
        [ForeignKey("Telefone")]
        public int TelefoneId { get; set; }
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index("User_Login", IsUnique = true)]
        public string Nome { get; set; }
        public string Senha { get; set; }
        public virtual Telefone Telefone { get; set; }
        public virtual Endereco Endereco { get; set; }
        

        

    }
}