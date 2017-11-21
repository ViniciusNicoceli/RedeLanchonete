using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Favorito
    {
        [Key]
        public int FavoritoId { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [ForeignKey("Restaurante")]
        public int RestauranteId { get; set; }
        


        public virtual Usuario Usuario { get; set; }
        public virtual Restaurante Restaurante { get; set; }
    }
}