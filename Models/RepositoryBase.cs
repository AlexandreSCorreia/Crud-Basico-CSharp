using System.Collections.Generic;
using System.Linq;

namespace CRUD.Models
{
 public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        protected List<TEntity> lista = new List<TEntity>();

        private int UltimoId = 1;

        protected int NextId()
        {
            var count = lista.Count + 1;

            if (count == 0)
            {
                return UltimoId;
            }

            if (count < UltimoId)
            {
                var valor = UltimoId;
                UltimoId++;
                return valor;
            }

            UltimoId++;
            return count;
        }

        public List<TEntity> FindAll()
        {
            return lista;
        }

        public TEntity Find(int id)
        {
            var objEncontrado = lista.FirstOrDefault(obj => obj.Id == id);
            return objEncontrado;
        }

        public bool Create(TEntity obj)
        {
            try
            {
                obj.Id = NextId();
                lista.Add(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int id, TEntity obj)
        {
            try
            {
                var objEncontrado = this.Find(id);
                if (objEncontrado == null)
                {
                    return false;
                }

                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (prop.Name != "Id")
                    {
                        prop.SetValue(objEncontrado, prop.GetValue(obj));
                    }
                }
                        
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Destroy(int id)
        {
            try
            {
                var objEncontrado = this.Find(id);

                if(objEncontrado == null)
                {
                    return false;
                }

                lista.Remove(objEncontrado);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}