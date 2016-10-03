using System.Web.Mvc;
using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IBusiness;
using System;

namespace LocadoraDigitalMVC.Controllers
{
    public class GenerosController : Controller
    {
        //private GeneroRepository d1b = new GeneroRepository();

        private readonly IGeneroBusiness generoBusiness;

        public GenerosController(IGeneroBusiness _generoBusiness)
        {
            this.generoBusiness = _generoBusiness;
        }


        public ActionResult Index(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
            {
                return View(generoBusiness.GetAll());
            }
            else
            {
                return View(generoBusiness.GetByFilter(descricao));
            }
        }

        public ActionResult Details(int id)
        {
            Genero genero = generoBusiness.Get(id);
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
                generoBusiness.Create(genero);
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        public ActionResult Edit(int id)
        {
            Genero genero = generoBusiness.Get(id);
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
                generoBusiness.Update(genero);
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        public ActionResult Delete(int id)
        {
            Genero genero = generoBusiness.Get(id);
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
            Genero genero = generoBusiness.Get(id);
            generoBusiness.Delete(genero);

            return RedirectToAction("Index");
        }

    }
}
