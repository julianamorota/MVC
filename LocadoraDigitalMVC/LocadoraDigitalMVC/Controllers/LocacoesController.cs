using System.Web.Mvc;
using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IBusiness;
using System;
using System.Collections.Generic;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System.Linq;

namespace LocadoraDigitalMVC.Controllers
{
    public class LocacoesController : Controller
    {
        private LocadoraDigitalMVCContext mudar = new LocadoraDigitalMVCContext();
        //private LocacaoRepository locacaoBusiness = new LocacaoRepository();

        private readonly ILocacaoBusiness locacaoBusiness;
        
        public LocacoesController(ILocacaoBusiness _locacaoBusiness)
        {
            this.locacaoBusiness = _locacaoBusiness;
        }

        public ActionResult Index(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao)
        {
            //MUDAR ISSO
            var ClienteLst = new List<string>();
            var FilmeLst = new List<string>();

            var ClienteQry = from d in mudar.Clientes
                           orderby d.Nome
                           select d.Nome;

            var FilmeQry = from d in mudar.Filmes
                           orderby d.Nome
                           select d.Nome;

            ClienteLst.AddRange(ClienteQry.Distinct());
            FilmeLst.AddRange(FilmeQry.Distinct());
            ViewBag.nomeCliente = new SelectList(ClienteLst);
            ViewBag.nomeFilme = new SelectList(FilmeLst);

            return View(locacaoBusiness.GetByFilter(nomeCliente, nomeFilme, dtLocacao, dtDevolucao));
        }
        
        public ActionResult Details(int id)
        {
            Locacao locacao = locacaoBusiness.Get(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        public ActionResult Create()
        {
            var filmesDisp = from f in mudar.Filmes
                             select f;
            filmesDisp = filmesDisp.Where(x => x.Status == true);

            ViewBag.ClienteId = new SelectList(mudar.Clientes, "Id", "Nome");
            
            ViewBag.FilmeId = new SelectList(filmesDisp, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,FilmeId,dtLocacao,dtDevolucao")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                locacaoBusiness.Create(locacao);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(mudar.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.FilmeId = new SelectList(mudar.Filmes, "Id", "Nome", locacao.FilmeId);
            return View(locacao);
        }

        public ActionResult Edit(int id)
        {
            Locacao locacao = locacaoBusiness.Get(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClienteId = new SelectList(mudar.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.FilmeId = new SelectList(mudar.Filmes, "Id", "Nome", locacao.FilmeId);
            return View(locacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,FilmeId,dtLocacao,dtDevolucao")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                locacaoBusiness.Update(locacao);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(mudar.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.FilmeId = new SelectList(mudar.Filmes, "Id", "Nome", locacao.FilmeId);
            return View(locacao);
        }
        
        public ActionResult Devolucao(int id)
        {
            Locacao locacao = locacaoBusiness.Get(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        [HttpPost, ActionName("Devolucao")]
        [ValidateAntiForgeryToken]
        public ActionResult Devolvido(int id)
        {
            Locacao locacao = locacaoBusiness.Get(id);
           
            locacaoBusiness.Devolucao(locacao);
            return RedirectToAction("Index","Devolucoes");
        }

     }
}
