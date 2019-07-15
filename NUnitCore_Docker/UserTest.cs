using Core_BAL;
using Core_DALInterface;
using Core_Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_Nunit
{
    public class UserTest
    {
        #region Variable Declaration 
        public UserBAL userBAL = null;
        public List<User> usersList;
        public readonly IRepository<User> MockUsersRepository;
        #endregion

        [SetUp]
        public void Setup()
        {
        }

        #region constructor  
        public UserTest()
        {
            Mock<IRepository<User>> mockUserRepository = new Mock<IRepository<User>>();
            usersList = GetUserList();

            // setup for Fetch all Users
            mockUserRepository.Setup(mr => mr.FetchAll()).ReturnsAsync(usersList);
            // Setup for Insert user
            mockUserRepository.Setup(repo => repo.Insert(It.IsAny<User>())).ReturnsAsync(
                (User target) =>
                {
                    usersList.Add(target);
                    var inserted = new Tuple<int, bool>(Convert.ToInt32(usersList.Count), Convert.ToInt32(usersList.Count) > 0);
                    return inserted;
                });

            // Setup for get  UserById
            mockUserRepository.Setup(mr => mr.FetchById(
                It.IsAny<int>())).ReturnsAsync((int i) => usersList.Find(
                x => x.UserId == i));

            //setup for Delete User
            mockUserRepository.Setup(mr => mr.Delete(It.IsAny<User>(),
               It.IsAny<int>())).ReturnsAsync((User target,int i) =>
               {
                   int usersCountBeforeDelete = usersList.Count;
                   usersList.Remove(target);
                   int usersCountAfterDelete = usersList.Count;
                   return usersCountAfterDelete < usersCountBeforeDelete;
               });

            this.MockUsersRepository = mockUserRepository.Object;
        }

        #endregion

        #region Test Methods

        [Test]
        public void GetUsersAsync()
        {
            var usersList = this.MockUsersRepository.FetchAll();
            Assert.IsNotNull(usersList);
            Assert.IsNotNull(usersList.Result);
            Assert.AreEqual(2, usersList.Result.Count);
        }

        [Test]
        public async Task InsertUserAsync()
        {
            User usr = new User { UserId = 3, FirstName = "Ram", LastName = "B" };
            var inserted = await this.MockUsersRepository.Insert(usr);
            Assert.AreEqual(3, Convert.ToInt32(inserted.Item1));
            Assert.IsTrue(inserted.Item2);
        }

        [Test]
        public async Task GetUserByIdAsync()
        {
            User testUser = await this.MockUsersRepository.FetchById(2);
            Assert.IsNotNull(testUser);
            Assert.AreEqual("udarapu", testUser.FirstName);
        }

        [Test]
        public async Task DeleteUserAsync()
        {
            User testUser = await this.MockUsersRepository.FetchById(1000);
            bool isDeleted = await this.MockUsersRepository.Delete(testUser,testUser.UserId);
            int afterDeletedUser = usersList.Count;
            Assert.IsNotNull(isDeleted);
            Assert.AreEqual(afterDeletedUser, usersList.Count);
        }
        #endregion

        #region private methods
        private List<User> GetUserList()
        {
            List<User> users = new List<User>();
            users.Add(new User()
            {
                UserId = 1,
                FirstName = "Gopi",
                LastName = "Nagaraju"
            });
            users.Add(new User()
            {
                UserId = 2,
                FirstName = "udarapu",
                LastName = "Nagaraju"
            });

            users.Add(new User()
            {
                UserId = 1000,
                FirstName = "abc",
                LastName = "xyz"
            });
            return users;
        }
        #endregion
    }
}