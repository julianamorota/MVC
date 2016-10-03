using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using LocadoraDigitalMVC.Repository.EntityFramework;
using LocadoraDigitalMVC.IBusiness;

namespace LocadoraDigitalMVC.Controllers
{
    public class FilmesController : Controller
    {
        private LocadoraDigitalMVCContext mudar = new LocadoraDigitalMVCContext();
        //private FilmeRepository db = new FilmeRepository();

        private readonly IFilmeBusiness filmeBusiness;
        public FilmesController(IFilmeBusiness _filmeBusiness)
        {
            this.filmeBusiness = _filmeBusiness;
        }

        public ActionResult Index(string nomeFilme,string nomeGenero, string status)
        {
            //MUDAR ISSO 
            var GenreLst = new List<string>();

            var GenreQry = from d in mudar.Generos
                           orderby d.Descricao
                           select d.Descricao;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.nomeGenero = new SelectList(GenreLst);

            return View(filmeBusiness.GetByFilter(nomeFilme, nomeGenero, status));
            //return View(filmeBusiness.GetAll());
          
        }

        public ActionResult Details(int id)
        {
            Filme filme = filmeBusiness.Get(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(mudar.Generos, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,GeneroId")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                
                filmeBusiness.Create(filme);
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(mudar.Generos, "Id", "Descricao", filme.GeneroId);
            return View(filme);
        }

        public ActionResult Edit(int id)
        {
            Filme filme = filmeBusiness.Get(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroId = new SelectList(mudar.Generos, "Id", "Descricao", filme.GeneroId);
            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,GeneroId")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                
                filmeBusiness.Update(filme);
                return RedirectToAction("Index");
            }
            ViewBag.GeneroId = new SelectList(mudar.Generos, "Id", "Descricao", filme.GeneroId);
            return View(filme);
        }

        public ActionResult Delete(int id)
        {
           
            Filme filme = filmeBusiness.Get(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = filmeBusiness.Get(id);
            filmeBusiness.Delete(filme);
            return RedirectToAction("Index");
        }

    }
}
