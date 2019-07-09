using System;
using System.Collections.Generic;
using Core_DALInterface;
using Core_DomainModel;
using Core_BALInterfaceCore;
using System.Threading.Tasks;
//using Core

namespace Core_BAL
{

    public class UserBAL: IUserBAL
    {

        private IUserDAL userDAL;
        public UserBAL(IUserDAL userDAL) {
            this.userDAL = userDAL;
            }
        public List<User> GetUsers()
        {
            return userDAL.GetUsers();
        }

        public Task<User> Authenticate()
        {
            User user;
            user = new User { UserId = 1, UserName="Suman" };
            return Task.FromResult<User>(user);
        }
    }
}
