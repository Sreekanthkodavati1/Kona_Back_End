using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core_DALInterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> FetchAll();
        Task<TEntity> FetchById(int id);
        Task<Tuple<int, bool>> Insert(TEntity entity);
        Task<bool> Delete(TEntity entity, int id);
        Task<bool> Save(TEntity entity);
        Task<bool> Update(TEntity entity);
    }
}
