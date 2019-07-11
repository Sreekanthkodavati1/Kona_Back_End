using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_BALInterfaceCore
{
    public interface IEntityBAL<T> where T : class
    {
        Task<List<T>> GetUsers();
        Task<T> GetUserById(int id);
        Task<Tuple<int,bool>> Insert(T entity);
        Task<bool> Delete(T entity, int id);
        Task<bool> Save(T entity);
        Task<bool> Update(T entity);
    }
}
