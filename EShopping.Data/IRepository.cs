using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShopping.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> SaveChangesAsync();
        IEnumerable<TEntity> GetAllWithIncludes(string[] includes);
    }
}
