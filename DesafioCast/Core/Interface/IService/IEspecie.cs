using System.Collections.Generic;
using Core.Model;

namespace Core.Interface.IService
{
    public interface IEspecieService
    {
        IList<Especie> GetAll();
        bool Add(Especie especie);
        bool Update(Especie especie);
        bool Delete(int id);
        Especie GetEspecie(int Id);
    }
}
