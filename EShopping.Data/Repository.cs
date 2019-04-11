using EShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EShopping.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private EShoppingEntities _db;
        private IDbSet<TEntity> dbEntity;

        public Repository(EShoppingEntities db) {
            _db = db;
            dbEntity = _db.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            dbEntity.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbEntity.ToList();
        }

        public IQueryable<TEntity> GetAllWithIncludes(string[] includes)
        {
            var query = dbEntity.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public TEntity GetById(int Id)
        {
            return dbEntity.Find(Id);
        }

        public void Insert(TEntity entity)
        {
            dbEntity.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _db.SaveChangesAsync()) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
