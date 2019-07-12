using System;
using System.Collections.Generic;
using Core_DALInterface;

using Core_BALInterfaceCore;
using System.Threading.Tasks;
using Core_Domain;
//using Core

namespace Core_BAL
{

    public class UserBAL : IEntityBAL<User>
    {

        private IRepository<User> userRepository;
        public UserBAL(IRepository<User> userDAL)
        {
            this.userRepository = userDAL;
        }

        public async Task<List<User>> GetUsers()
        {
            var userList = await userRepository.FetchAll();
            return userList;
        }
        public async Task<Tuple<int, bool>> Insert(User entity)
        {

            return await userRepository.Insert(entity);
        }

        public async Task<User> GetUserById(int id)
        {
            var userList = await userRepository.FetchById(id);
            return userList;
        }
        public async Task<bool> Delete(User entity, int id)
        {
            return await userRepository.Delete(entity, id);
        }
        public async Task<bool> Save(User entity)
        {
            return await userRepository.Save(entity);
        }
        public async Task<bool> Update(User entity)
        {
            return await userRepository.Update(entity);
        }
    }
}
