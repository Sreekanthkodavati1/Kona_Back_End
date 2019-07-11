using Core_BAL;
using Core_DALInterface;
using Core_DomainModel;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_Nunit
{
    public class UserTest
    {
        public UserBAL userBAL = null;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetUsersAsync()
        {

            var mockRepo = new Mock<IRepository<User>>();
            mockRepo.Setup(repo => repo.FetchAll())
                .ReturnsAsync(GetUserList());
            userBAL = new UserBAL(mockRepo.Object);
            List<User> users = await userBAL.GetUsers();

            Assert.IsNotNull(users);
            Assert.AreEqual(2, users.Count);


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