using Core.Interface.Repository;
using Core.Interface.IService;
using Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public class AnimalService : IAnimalService
    {
        IRepository<Animal> _animalRepository;
        public AnimalService(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public bool Add(Animal animal)
        {
            if (animal.IsValid)
                return _animalRepository.Insert(animal);

            return false;
        }

        public bool Delete(int id)
        {
            var animal = GetAnimal(id);
            return _animalRepository.Delete(animal);
        }

        public Animal GetAnimal(int Id)
        {
            return _animalRepository.GetAll()
                                     .Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Animal> GetAll()
        {
            return _animalRepository.GetAll().ToList();
        }
              

        public bool Update(Animal animal)
        {
            if (animal.IsValid)
            {
                GetAnimal(animal.Id).Update(animal);

                return _animalRepository.SaveChanges();
            }

            return false;
        }
    }
}
