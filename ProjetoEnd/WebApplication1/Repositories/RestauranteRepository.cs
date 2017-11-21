using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAO
{
    public class RestauranteRepository : BaseRepository<Restaurante>
    {
        public override void Remove(int restauranteId)
        {
            using (var contexto = new RedeComercialContext())
            {

                foreach (var produto in contexto.Produtos
                    .Where(produto => produto.RestauranteId == restauranteId))
                {
                    contexto.Produtos.Remove(produto);
                }
                contexto.Restaurantes.Remove(contexto.Restaurantes.Find(restauranteId));
                contexto.SaveChanges();
            }
        }
    }
}