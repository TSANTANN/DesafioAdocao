using Core.Model;
using System.Collections.Generic;

namespace Core.Interface.IService
{
    public interface IUsuarioService
    {
        IList<Usuario> GetAll();
        bool Add(Usuario usuario);
        bool Update(Usuario usuario);
        bool Delete(int id);
        Usuario GetUsuario(int Id);
    }
}
