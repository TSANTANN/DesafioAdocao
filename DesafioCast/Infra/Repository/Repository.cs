using Core.Interface.Repository;
using Infra.Context;
using System;
using System.Data.Entity;
using System.Linq;

namespace Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext _db;
        public Repository()
        {
            _db = new DesafioDBContext();
        }

        public bool Delete(T entity)
        {
            try
            {
                _db.Set<T>().Remove(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsQueryable();
        }

        public bool Insert(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
