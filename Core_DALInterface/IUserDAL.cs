using Core_DomainModel;
using System;
using System.Collections.Generic;

namespace Core_DALInterface
{
    public interface IUserDAL
    {
        List<User> GetUsers();
    }
}
