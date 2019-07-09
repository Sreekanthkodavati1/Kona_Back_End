using Core_DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Peta

namespace Core_BALInterfaceCore
{
    public interface IUserBAL
    {
        List<User> GetUsers();
        Task<User> Authenticate();

    }
}
