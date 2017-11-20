using WebApplication1.DAO;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Filtros;
using System.Net;

namespace WebApplication1.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosRepository dao = new ProdutosRepository();
            var produtos = dao.Lista();
            ViewBag.Usuario = (Usuario)Session["usuarioLogado"];
            ViewBag.Restaurante = (Restaurante)Session["restauranteAtual"];
            return View(produtos);
        }
        public ActionResult Form()
        {
            ViewBag.Produto = new Produto();
            return View();
        }
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            Restaurante restaurante = (Restaurante)Session["restauranteAtual"];

            produto.RestauranteId = restaurante.RestauranteId;

            ProdutosRepository dao = new ProdutosRepository();
            dao.Adiciona(produto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Remover(int id)
        {
            ProdutosRepository dao = new ProdutosRepository();
            dao.Remove(id);

            return RedirectToAction("Index");
        }
        public ActionResult Modificar(int produtoId)
        {
            ProdutosRepository dao = new ProdutosRepository();
            Produto produto = dao.Busca(produtoId);
            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }
        [HttpPost]
        public ActionResult Modificar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutosRepository dao = new ProdutosRepository();
                Produto produtoAntigo = new Produto();
                produtoAntigo = dao.Busca(produto.ProdutoId);
                produtoAntigo.Modificar(produto);
                dao.Atualiza(produtoAntigo);
                return RedirectToAction("Index");
            }
            return View(produto);
        }


    }
}