using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.Interface.IService;
using Core.Model;
using Infra.Context;

namespace Web.Mvc.Controllers
{
    public class EspecieController : Controller
    {
        // private DesafioDBContext db = new DesafioDBContext();

        IEspecieService _especieService;
        public EspecieController(IEspecieService especieService)
        {
            _especieService = especieService;
        }
        // GET: Especie
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(_especieService.GetAll());
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
           
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {

            Especie especie = _especieService.GetEspecie(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _especieService.Add(especie);
                return RedirectToAction("Index");
            }

            return View(especie);
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {

            Especie especie = _especieService.GetEspecie(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Especie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _especieService.Update(especie);
                return RedirectToAction("Index");
            }
            return View(especie);
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {

            Especie especie = _especieService.GetEspecie(id);
            if (especie == null)
            {
                return HttpNotFound();
            }
            return View(especie);
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especie especie = _especieService.GetEspecie(id);
            _especieService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
