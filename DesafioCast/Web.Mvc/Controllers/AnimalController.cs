using System.Linq;
using System.Web.Mvc;
using Core.Interface.IService;
using Core.Model;
using Infra.Context;

namespace Web.Mvc.Controllers
{
    public class AnimalController : Controller
    {
       // private DesafioDBContext db = new DesafioDBContext();
      
        IAnimalService _animalService;
        IEspecieService _especieService;
        IAdotanteService _adotanteService;
         
        public AnimalController(IAnimalService animalService,IEspecieService especieService, IAdotanteService adotanteService)
        {           
            _animalService = animalService;
            _especieService = especieService;
            _adotanteService = adotanteService;
        }

        // GET: Animal
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                var animaldisponivel = _animalService.GetAll().Where(a => !_adotanteService.GetAll().Any(e => e.AnimalId == a.Id));
                //var animais = db.Animais.Include(a => a.Especie);
                return View(animaldisponivel.ToList());
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
          
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
           
            Animal animal = _animalService.GetAnimal(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            ViewBag.EspecieId = new SelectList(_especieService.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EspecieId,Raca,Nome,Idade,Sexo,DataEntrada")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                
                _animalService.Add(animal);                
                return RedirectToAction("Index");
            }

            ViewBag.EspecieId = new SelectList(_especieService.GetAll(), "Id", "Nome", animal.EspecieId);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
           
            Animal animal = _animalService.GetAnimal(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecieId = new SelectList(_especieService.GetAll(), "Id", "Nome", animal.EspecieId);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EspecieId,Raca,Nome,Idade,Sexo,DataEntrada")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _animalService.Update(animal);
                return RedirectToAction("Index");
            }
            ViewBag.EspecieId = new SelectList(_especieService.GetAll(), "Id", "Nome", animal.EspecieId);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            
            Animal animal = _animalService.GetAnimal(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             _animalService.Delete(id);           
            return RedirectToAction("Index");
        }

    }
}
