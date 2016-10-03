using System.Web.Mvc;
using LocadoraDigitalMVC.Entities;
using LocadoraDigitalMVC.IBusiness;
using System;

namespace LocadoraDigitalMVC.Controllers
{
    public class ClientesController : Controller
    {

        #region dependency injection
        private readonly IClienteBusiness clienteBusiness;

        public ClientesController(IClienteBusiness _clienteBusiness)
        {
            this.clienteBusiness = _clienteBusiness;
        }
        #endregion

        public ActionResult Index(string nome, string cpf)
        {
            if (String.IsNullOrEmpty(nome) && String.IsNullOrEmpty(cpf))
            {
                return View(clienteBusiness.GetAll());
            }
            else
            {
                return View(clienteBusiness.GetByFilter(nome, cpf));
            }
        }

        public ActionResult Details(int id)
        {
            Cliente cliente = clienteBusiness.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Telefone,Endereco")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteBusiness.Create(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            Cliente cliente = clienteBusiness.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,Telefone,Endereco")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteBusiness.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            Cliente cliente = clienteBusiness.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = clienteBusiness.Get(id);
            clienteBusiness.Delete(cliente);
            return RedirectToAction("Index");
        }
    }
}
