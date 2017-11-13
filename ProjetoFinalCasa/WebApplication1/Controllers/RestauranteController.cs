using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Filtros;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [AutorizacaoFilter]
    public class RestauranteController : Controller
    {

        RestauranteRepository rep = new RestauranteRepository();
        TelefoneRepository trep = new TelefoneRepository();
        EnderecoRepository erep = new EnderecoRepository();
        FavoritoRepository frep = new FavoritoRepository();
        // GET: Restaurante
        public ActionResult Index()
        {
            ViewBag.Usuario = (Usuario)Session["usuarioLogado"];
            var restaurantes = rep.Lista();
            var telefones = trep.Lista();
            var enderecos = erep.Lista();
            ViewBag.Telefones = telefones;
            ViewBag.Enderecos = enderecos;
            return View(restaurantes);
        }
        public ActionResult Form()
        {
            var Restaurante = new Restaurante();
            return View(Restaurante);
        }
        
        public ActionResult Global()
        {
            ViewBag.Usuario = (Usuario)Session["usuarioLogado"];
            var restaurantes = rep.Lista();
            var telefones = trep.Lista();
            var enderecos = erep.Lista();
            ViewBag.Telefones = telefones;
            ViewBag.Enderecos = enderecos;
            return View(restaurantes);
        }

        public ActionResult PegarProdutos(int restauranteId)
        {
            Restaurante restaurante = rep.Busca(restauranteId);
            if (restaurante != null)
            {
                Session["restauranteAtual"] = restaurante;

                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Adiciona(Restaurante restaurante)
        {
            Usuario usuario = (Usuario)Session["usuarioLogado"];

            restaurante.UsuarioId = usuario.UsuarioId;
            rep.Adiciona(restaurante);
            trep.Adiciona(restaurante.Telefone);
            erep.Adiciona(restaurante.Endereco);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Remover(int id)
        {
            rep.Remove(id);
            
            return RedirectToAction("Index");
        }


        public ActionResult Modificar(int restauranteId, int telefoneId, int enderecoId)
        {
            Restaurante restaurante = rep.Busca(restauranteId);

            Telefone telefone = trep.Busca(telefoneId);

            Endereco endereco = erep.Busca(enderecoId);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            restaurante.Endereco = endereco;
            restaurante.Telefone = telefone;
            return View(restaurante);
        }
        [HttpPost]
        public ActionResult Modificar(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {

                Restaurante restauranteAntigo = new Restaurante();

                restauranteAntigo = rep.Busca(restaurante.RestauranteId);
                restauranteAntigo.Telefone = trep.Busca(restaurante.TelefoneId);
                restauranteAntigo.Endereco = erep.Busca(restaurante.EnderecoId);

                restauranteAntigo.Modificar(restaurante);
                restauranteAntigo.Telefone.Modificar(restaurante.Telefone);
                restauranteAntigo.Endereco.Modificar(restaurante.Endereco);

                rep.Atualiza(restauranteAntigo);
                trep.Atualiza(restauranteAntigo.Telefone);
                erep.Atualiza(restauranteAntigo.Endereco);
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        [HttpPost]
        public ActionResult Favoritar(int id)
        {
            Usuario usuario = (Usuario)Session["usuarioLogado"];
            Restaurante restaurante = rep.Busca(id);
            Favorito Favorito = new Favorito();
            Favorito.RestauranteId = restaurante.RestauranteId;
            Favorito.UsuarioId = usuario.UsuarioId;
            var favoritos = frep.Lista();
            Boolean JaExiste = false;
            foreach(var fav in favoritos)
            {
                if((fav.UsuarioId == Favorito.UsuarioId) && (fav.RestauranteId == Favorito.RestauranteId))
                {
                    JaExiste = true;
                    break;
                }
            }
            if (!JaExiste)
            {
                frep.Adiciona(Favorito);
            }
            return RedirectToAction("Index");
        }
    }
}