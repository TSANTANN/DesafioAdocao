using Core.Interface.IService;
using Core.Interface.Repository;
using Core.Service;
using Infra.Repository;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Web.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IEspecieService, EspecieService>();
            container.RegisterType<IAnimalService, AnimalService>();
            container.RegisterType<IPessoaService, PessoaService>();
            container.RegisterType<IAdotanteService, AdotanteService>();
            container.RegisterType<IUsuarioService, UsuarioService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}