using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.Model;
using Infra.Context;
using Core.Interface.IService;

namespace Web.Mvc.Controllers
{
    public class AdotanteController : Controller
    {
       // private DesafioDBContext db = new DesafioDBContext();

        IAnimalService _animalService;
        IAdotanteService _adotanteService;
        IPessoaService _pessoaService;
        public AdotanteController(IAdotanteService adotanteService, IAnimalService animalService, IPessoaService pessoaService)
        {
            _animalService = animalService;
            _adotanteService = adotanteService;
            _pessoaService = pessoaService;
        }

        // GET: Adotante
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                var animaldisponivel = _animalService.GetAll().Where(a => !_adotanteService.GetAll().Any(e => e.AnimalId == a.Id));


                if (animaldisponivel.ToList().Count() == 0)
                {
                    ViewBag.Message = "Não há animais para adotar!";
                }

                return View(_adotanteService.GetAll());
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            // var adotantes = db.Adotantes.Include(a => a.Animal).Include(a => a.Pessoa);
          
        }

        // GET: Adotante/Details/5
        public ActionResult Details(int id)
        {
          
            Adotante adotante = _adotanteService.GetAdotante(id);
            if (adotante == null)
            {
                return HttpNotFound();
            }
            return View(adotante);
        }

        // GET: Adotante/Create
        public ActionResult Create()
        {
            var animaldisponivel = _animalService.GetAll().Where(x => !_adotanteService.GetAll().Any(y => y.AnimalId == x.Id));


            if (animaldisponivel.ToList().Count() == 0)
            {
                return RedirectToAction("Index", "Adotante");
            }
           

            ViewBag.AnimalId = new SelectList(animaldisponivel, "Id", "Nome");
            ViewBag.PessoaId = new SelectList(_pessoaService.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Adotante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PessoaId,AnimalId,DataAdocao")] Adotante adotante)
        {
            if (ModelState.IsValid)
            {
                _adotanteService.Add(adotante);
               
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(_animalService.GetAll(), "Id", "Nome");
            ViewBag.PessoaId = new SelectList(_pessoaService.GetAll(), "Id", "Nome");
            return View(adotante);
        }

        // GET: Adotante/Edit/5
        public ActionResult Edit(int id)
        {
            
            Adotante adotante = _adotanteService.GetAdotante(id);
            if (adotante == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(_animalService.GetAll(), "Id", "Nome");
            ViewBag.PessoaId = new SelectList(_pessoaService.GetAll(), "Id", "Nome");
            return View(adotante);
        }

        // POST: Adotante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PessoaId,AnimalId,DataAdocao")] Adotante adotante)
        {
            if (ModelState.IsValid)
            {
                _adotanteService.Update(adotante);
               
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(_animalService.GetAll(), "Id", "Nome");
            ViewBag.PessoaId = new SelectList(_pessoaService.GetAll(), "Id", "Nome");
            return View(adotante);
        }

        // GET: Adotante/Delete/5
        public ActionResult Delete(int id)
        {
            
            Adotante adotante = _adotanteService.GetAdotante(id);
            if (adotante == null)
            {
                return HttpNotFound();
            }
            return View(adotante);
        }

        // POST: Adotante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {           
            _adotanteService.Delete(id);
          
            return RedirectToAction("Index");
        }

    }
}
