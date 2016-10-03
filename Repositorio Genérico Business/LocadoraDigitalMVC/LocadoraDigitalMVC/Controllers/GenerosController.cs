using System.Web.Mvc;
using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IBusiness;
using System;
using LocadoraDigitalMVC.IRepository;

namespace LocadoraDigitalMVC.Controllers
{
    public class GenerosController : Controller
    {

        private readonly IGeneroRepository generoRepository;

        public GenerosController(IGeneroRepository _generoRepository)
        {
            this.generoRepository = _generoRepository;
        }


        public ActionResult Index(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                return View(generoRepository.GetAll());
            }
            else
            {
                return View(generoRepository.GetByFilter(x => x.Descricao.Contains(descricao)));
            }
        }

        public ActionResult Details(int id)
        {
            Genero genero = generoRepository.Get(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                generoRepository.Create(genero);
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        public ActionResult Edit(int id)
        {
            Genero genero = generoRepository.Get(id);
            if (genero == null)
            {
                return HttpNotFound();
            }

            return View(genero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                generoRepository.Update(genero);
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        public ActionResult Delete(int id)
        {
            Genero genero = generoRepository.Get(id);
            if (genero == null)
            {
                return HttpNotFound();
            }

            return View(genero);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = generoRepository.Get(id);
            generoRepository.Delete(genero);

            return RedirectToAction("Index");
        }

    }
}
