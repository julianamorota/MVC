using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using LocadoraDigitalMVC.Repository.EntityFramework;
using System.Collections.Generic;
using System;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.IBusiness;
using LocadoraDigitalMVC.Business;

namespace LocadoraDigitalMVC.Controllers
{
    public class DevolucoesController : Controller
    {
        private LocadoraDigitalMVCContext d1b1 = new LocadoraDigitalMVCContext();
        private DevolucaoRepository d1b = new DevolucaoRepository();

        private readonly IDevolucaoBusiness devolucaoBusiness;

        public DevolucoesController(IDevolucaoBusiness _devolucaoBusiness)
        {
            this.devolucaoBusiness = _devolucaoBusiness;
        }

        public ActionResult Index(string nomeCliente, string nomeFilme, DateTime? dtLocacao, DateTime? dtDevolucao)
        {
            //MUDAR ISSO
            var ClienteLst = new List<string>();
            var FilmeLst = new List<string>();

            var ClienteQry = from d in d1b1.Clientes
                             orderby d.Nome
                             select d.Nome;

            var FilmeQry = from d in d1b1.Filmes
                           orderby d.Nome
                           select d.Nome;

            ClienteLst.AddRange(ClienteQry.Distinct());
            FilmeLst.AddRange(FilmeQry.Distinct());
            ViewBag.nomeCliente = new SelectList(ClienteLst);
            ViewBag.nomeFilme = new SelectList(FilmeLst);

            
            return View(devolucaoBusiness.GetByFilter(nomeCliente, nomeFilme, dtLocacao, dtDevolucao));
        }


        public ActionResult Details(int id)
        {
            Devolucao devolucao = devolucaoBusiness.Get(id);
            if (devolucao == null)
            {
                return HttpNotFound();
            }
            return View(devolucao);
        }

       
    }
}
 