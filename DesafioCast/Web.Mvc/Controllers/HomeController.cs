using Core.Interface.IService;
using Core.Model;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        IAnimalService _animalService;
        IAdotanteService _adotanteService;
        IPessoaService _pessoaService;
        IUsuarioService _usuarioService;
        public HomeController(IAdotanteService adotanteService, IAnimalService animalService, IPessoaService pessoaService, IUsuarioService usuarioService)
        {
            _animalService = animalService;
            _adotanteService = adotanteService;
            _pessoaService = pessoaService;
            _usuarioService = usuarioService;
        }
        public ActionResult Index()
        {
            try
                {
                    if (_animalService.GetAll().Where(a => !_adotanteService.GetAll().Any(e => e.AnimalId == a.Id)).Count() > 1)
                    {
                        ViewBag.menssageanimalantigo = _animalService.GetAll().Where(a => !_adotanteService.GetAll().Any(e => e.AnimalId == a.Id)).FirstOrDefault().Nome;
                    }
                    else
                    {
                        ViewBag.menssageanimalantigo = null;
                    }
                    ViewBag.menssageanimalnovo = _animalService.GetAll().Where(a => !_adotanteService.GetAll().Any(e => e.AnimalId == a.Id)).LastOrDefault().Nome;                
                }
            catch (Exception)
                {
                ViewBag.menssageanimalantigo = null;
                ViewBag.menssageanimalnovo = null;
            }
            try
            {
                ViewBag.menssagenomeadotante = _adotanteService.GetAll().LastOrDefault().Pessoa.Nome;
                ViewBag.menssagenomeanimal = _adotanteService.GetAll().LastOrDefault().Animal.Nome;
            }
            catch (Exception)
            {
                ViewBag.menssagenomeadotant = null;
                ViewBag.menssagenomeanimal = null;

            }

            return View();
        }

        public ActionResult Login(Usuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {

                var Validauser = _usuarioService.GetAll().Where(a => a.NomeUsuario.Equals(u.NomeUsuario) && a.Senha.Equals(u.Senha)).FirstOrDefault();
                if (Validauser != null)
                {
                    Session["usuarioLogadoID"] = Validauser.Id.ToString();
                    Session["nomeUsuarioLogado"] = Validauser.NomeUsuario.ToString();
                    return RedirectToAction("Index");

                }
            }
            return View(u);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sistema desenvolvido para o desafio da Cast Group";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}