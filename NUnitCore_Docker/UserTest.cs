using Core_BAL;
using Core_DALInterface;
using Core_Domain;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_Nunit
{
    public class UserTest
    {
        public UserBAL userBAL = null;
        public List<User> usersList;
        public readonly IRepository<User> MockUsersRepository;
        [SetUp]
        public void Setup()
        {
        }
        public UserTest()
        {
            Mock<IRepository<User>> mockUserRepository = new Mock<IRepository<User>>();
            usersList = GetUserList();
            mockUserRepository.Setup(mr => mr.FetchAll()).ReturnsAsync(usersList);
            this.MockUsersRepository = mockUserRepository.Object;
        }

        [Test]
        public void GetUsersAsync()
        {
            Assert.IsNotNull(usersList);
            Assert.AreEqual(2, usersList.Count);
        }

        private List<User> GetUserList()
        {
            var user = new List<User>();
            user.Add(new User()
            {
                UserId = 1,
                FirstName = "Gopi",
                LastName = "Nagaraju"
            });
            user.Add(new User()
            {
                UserId = 2,
                FirstName = "udarapu",
                LastName = "Nagaraju"
            });
            return user;
        }
    }
}