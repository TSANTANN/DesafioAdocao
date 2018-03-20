using System.Collections.Generic;
using Core.Model;

namespace Core.Interface.IService
{ 
        public interface IAnimalService
        {

            IList<Animal> GetAll();
            bool Add(Animal animal);
            bool Update(Animal animal);
            bool Delete(int id);
            Animal GetAnimal(int Id);
        }
}
