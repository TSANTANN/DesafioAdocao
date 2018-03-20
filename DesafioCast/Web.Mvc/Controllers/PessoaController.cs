using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Core.Interface.IService;
using Core.Model;
using Infra.Context;

namespace Web.Mvc.Controllers
{
    public class PessoaController : Controller
    {
        //private DesafioDBContext db = new DesafioDBContext();


        IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View(_pessoaService.GetAll());
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
           
            Pessoa pessoa = _pessoaService.GetPessoa(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cep,Telefone")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaService.Add(pessoa);
                
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            
            Pessoa pessoa = _pessoaService.GetPessoa(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cep,Telefone")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaService.Update(pessoa);
                
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            
            Pessoa pessoa = _pessoaService.GetPessoa(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            _pessoaService.Delete(id);
            
            return RedirectToAction("Index");
        }

    }
}
