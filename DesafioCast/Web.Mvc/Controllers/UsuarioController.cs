using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Core.Interface.IService;
using Core.Model;
using Infra.Context;


namespace Web.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        // private DesafioDBContext db = new DesafioDBContext();
       
        IUsuarioService _usuarioService;
        public UsuarioController( IUsuarioService usuarioService)
        {           
            _usuarioService = usuarioService;
        }
        // GET: Usuario
        public ActionResult Index()
        {
           
            if (Session["usuarioLogadoID"] != null)
            {
                return View(_usuarioService.GetAll());
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
           
            Usuario usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeUsuario,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Add(usuario);                
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
           
            Usuario usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeUsuario,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.Update(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
           
            Usuario usuario = _usuarioService.GetUsuario(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _usuarioService.Delete(id);
      
            return RedirectToAction("Index");
        }

     
    }
}
