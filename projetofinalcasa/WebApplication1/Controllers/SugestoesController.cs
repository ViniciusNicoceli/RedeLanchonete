using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Filtros;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [AutorizacaoFilter]
    public class SugestoesController : Controller
    {
        RestauranteRepository rep = new RestauranteRepository();
        SugestoesRepository srep = new SugestoesRepository();
        [AutorizacaoFilter]

        public ActionResult Form(int RestauranteId)
        {
            Session["restauranteAtual"] = rep.Busca(RestauranteId);
            Sugestoes sugestoes = new Sugestoes();
            return View(sugestoes);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Adiciona(Sugestoes sugestoes)
        {
            Restaurante restaurante = (Restaurante)Session["restauranteAtual"];
            Usuario Usuario = (Usuario)Session["usuarioLogado"];
            sugestoes.UsuarioId = Usuario.UsuarioId;
            sugestoes.RestauranteId = rep.Busca(restaurante.RestauranteId).RestauranteId;
            srep.Adiciona(sugestoes);
            return RedirectToAction("Index","Restaurante");
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            srep.Remove(id);

            return RedirectToAction("Sugestoes","Usuario");
        }
    }
}