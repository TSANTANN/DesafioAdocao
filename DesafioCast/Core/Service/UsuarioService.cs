using Core.Interface.Repository;
using Core.Interface.IService;
using Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public class UsuarioService : IUsuarioService
    {
        IRepository<Usuario> _UsuarioRepository;
        public UsuarioService(IRepository<Usuario> UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }
        public bool Add(Usuario usuario)
        {
            if (usuario.IsValid)
                return _UsuarioRepository.Insert(usuario);

            return false;
        }

        public bool Delete(int id)
        {
            var usuario = GetUsuario(id);
            return _UsuarioRepository.Delete(usuario);
        }

        public Usuario GetUsuario(int Id)
        {
            return _UsuarioRepository.GetAll()
                                     .Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Usuario> GetAll()
        {
            return _UsuarioRepository.GetAll().ToList();
        }


        public bool Update(Usuario usuario)
        {
            if (usuario.IsValid)
            {
                GetUsuario(usuario.Id).Update(usuario);

                return _UsuarioRepository.SaveChanges();
            }

            return false;
        }
    }
}
