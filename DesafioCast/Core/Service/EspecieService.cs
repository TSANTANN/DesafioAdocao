using Core.Interface.Repository;
using Core.Interface.IService;
using Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public class EspecieService : IEspecieService
    {
        IRepository<Especie> _especieRepository;
        public EspecieService(IRepository<Especie> especieRepository)
        {
            _especieRepository = especieRepository;
        }
        public bool Add(Especie especie)
        {
            if (especie.IsValid)
                return _especieRepository.Insert(especie);

            return false;
        }

        public bool Delete(int id)
        {
            var especie = GetEspecie(id);
            return _especieRepository.Delete(especie);
        }

        public Especie GetEspecie(int Id)
        {
            return _especieRepository.GetAll()
                                     .Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Especie> GetAll()
        {
            return _especieRepository.GetAll().ToList();
        }


        public bool Update(Especie especie)
        {
            if (especie.IsValid)
            {
                GetEspecie(especie.Id).Update(especie);

                return _especieRepository.SaveChanges();
            }

            return false;
        }
    }
}
