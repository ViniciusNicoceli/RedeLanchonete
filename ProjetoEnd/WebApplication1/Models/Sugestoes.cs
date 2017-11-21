using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Sugestoes
    {
        [Key]
        public int SugestoesId { get; set; }
        public int UsuarioId { get; set; }
        public int RestauranteId { get; set; }
        public string Sugestao { get; set; }

    }
}