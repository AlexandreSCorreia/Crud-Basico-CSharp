using System.Collections.Generic;

namespace CRUD.Models
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        public List<TEntity> FindAll();
        public TEntity Find(int id);
        public bool Create(TEntity obj);
        public bool Update(int id, TEntity obj);
        public bool Destroy(int id);
    }
}