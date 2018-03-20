using System.Collections.Generic;
using Core.Model;

namespace Core.Interface.IService
{
    public interface IAdotanteService
    {

        IList<Adotante> GetAll();
        bool Add(Adotante adotante);
        bool Update(Adotante adotante);
        bool Delete(int id);
        Adotante GetAdotante(int Id);
    }
}
