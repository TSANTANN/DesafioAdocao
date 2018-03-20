using System.Linq;
namespace Core.Interface.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        bool Insert(T entity);
        bool SaveChanges();
        bool Delete(T entity);
    }
}
