using Core.Interface.Repository;
using Core.Interface.IService;
using Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public class AdotanteService : IAdotanteService
    {
        IRepository<Adotante> _adotanteRepository;
        public AdotanteService(IRepository<Adotante> adotanteRepository)
        {
            _adotanteRepository = adotanteRepository;
        }
        public bool Add(Adotante adotante)
        {
            if (adotante.IsValid)
                return _adotanteRepository.Insert(adotante);

            return false;
        }

        public bool Delete(int id)
        {
            var adotante = GetAdotante(id);
            return _adotanteRepository.Delete(adotante);
        }

        public Adotante GetAdotante(int Id)
        {
            return _adotanteRepository.GetAll()
                                     .Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Adotante> GetAll()
        {
            return _adotanteRepository.GetAll().ToList();
        }


        public bool Update(Adotante adotante)
        {
            if (adotante.IsValid)
            {
                GetAdotante(adotante.Id).Update(adotante);

                return _adotanteRepository.SaveChanges();
            }

            return false;
        }
    }
}
