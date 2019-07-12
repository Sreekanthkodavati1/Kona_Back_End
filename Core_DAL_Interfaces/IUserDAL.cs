
using Core_Domain;
using System;
using System.Collections.Generic;

namespace Core_DAL_Interfaces
{
    public interface IUserDAL
    {
        List<User> GetUsers();
    }
}
