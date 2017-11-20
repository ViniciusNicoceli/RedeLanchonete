using WebApplication1.DAO;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Filtros;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        UsuarioRepository rep = new UsuarioRepository();
        RestauranteRepository rrep = new RestauranteRepository();
        TelefoneRepository trep = new TelefoneRepository();
        EnderecoRepository erep = new EnderecoRepository();
        FavoritoRepository frep = new FavoritoRepository();
        SugestoesRepository srep = new SugestoesRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            var Usuario = new Usuario();
            return View(Usuario);
        }
        
        public ActionResult Autentica(string login,string senha)
        {
            Usuario usuario = rep.BuscaPorLogin(login, senha);
            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                
                return RedirectToAction("Index", "Restaurante");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Adiciona(Usuario usuario)
        {
            rep.Adiciona(usuario);
            trep.Adiciona(usuario.Telefone);
            erep.Adiciona(usuario.Endereco);
            return RedirectToAction("Index");
        }
        [AutorizacaoFilter]
        public ActionResult Perfil(int? id)
        {
            int index;
            index = id.GetValueOrDefault();
            if(index != 0) {
                var Usuario = rep.Busca(index);
                IList<Favorito> favoritos = frep.Lista();
                favoritos = favoritos.Where(fav => fav.UsuarioId == Usuario.UsuarioId).ToList();
                IList<Restaurante> restaurantes = rrep.Lista();
                IList<Restaurante> restaurantesfavoritos = new List<Restaurante>();
                foreach (var restaurante in restaurantes)
                {
                    foreach (var restaurantefav in favoritos)
                    {
                        if (restaurantefav.RestauranteId == restaurante.RestauranteId)
                        {
                            var restaurantefavorito = restaurantes.FirstOrDefault(r => r.RestauranteId == restaurantefav.RestauranteId);
                            restaurantesfavoritos.Add(restaurantefavorito);
                        }
                    }
                }
                ViewBag.Favoritos = restaurantesfavoritos;
                ViewBag.Endereco = erep.Busca(Usuario.EnderecoId);
                ViewBag.Telefone = trep.Busca(Usuario.TelefoneId);
                return View(Usuario);
            }
            else
            {
                var Usuario = (Usuario)Session["usuarioLogado"];
                IList<Favorito> favoritos = frep.Lista();
                favoritos = favoritos.Where(fav => fav.UsuarioId == Usuario.UsuarioId).ToList();
                IList<Restaurante> restaurantes = rrep.Lista();
                IList<Restaurante> restaurantesfavoritos = new List<Restaurante>();
                foreach (var restaurante in restaurantes) {
                    foreach(var restaurantefav in favoritos)
                    {
                        if(restaurantefav.RestauranteId == restaurante.RestauranteId)
                        {
                            var restaurantefavorito = restaurantes.FirstOrDefault(r => r.RestauranteId == restaurantefav.RestauranteId);
                            restaurantesfavoritos.Add(restaurantefavorito);
                        }
                    }
                }
                ViewBag.Favoritos = restaurantesfavoritos;
                ViewBag.Endereco = erep.Busca(Usuario.EnderecoId);
                ViewBag.Telefone = trep.Busca(Usuario.TelefoneId);
                return View(Usuario);
            }
            
        }
        [AutorizacaoFilter]
        public ActionResult Sugestoes()
        {
            var Usuario = (Usuario)Session["usuarioLogado"];
            var restaurantes = rrep.Lista().Where(r => r.UsuarioId == Usuario.UsuarioId).ToList();

            var sugestoes = srep.Lista();
            ViewBag.Sugestoes = sugestoes;
            return View(restaurantes);
        }
        [AutorizacaoFilter]
        public ActionResult Procurar()
        {
            UsuarioRepository rep = new UsuarioRepository();
            var usuarios = rep.Lista();
            return View(usuarios);
        }
        [AutorizacaoFilter]
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            return RedirectToAction("Index");
        }
    }
}