using DL;
using Models;
using TranslaGenixAPI.Controllers;
using System.Collections.Generic;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BackendTests
{
    public class UserControllerTests
    {
        [Fact]
        public void GetAllUsersTest()
        {
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.GetAllUsers()).Returns(new List<User>());
            var mockCont = new UserController(mockRepo.Object);
            ActionResult actionResult = mockCont.Get();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
        [Fact]
        public void GetbyUsernameTest()
        {
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.GetUserByUserName(It.IsAny<string>())).Returns(new User());
            var mockCont = new UserController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetbyUsername("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void GetByEmailTest()
        {
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(new User());
            var mockCont = new UserController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetbyEmail("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void GetbyFirstnameTest()
        {
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.GetUserByFirstName(It.IsAny<string>())).Returns(new User());
            var mockCont = new UserController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetbyFirstname("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
        [Fact]
        public void GetByIdTest()
        {
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(new User());
            var mockCont = new UserController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetById(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void DeleteUserTest()
        {
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.GetUserByFirstName(It.IsAny<string>())).Returns(new User());
            mockRepo.Setup(x => x.DeleteUser(It.IsAny<string>()));
            var mockCont = new UserController(mockRepo.Object);
            ActionResult actionResult = mockCont.DeleteUser("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void UpdateUserTest()
        {
            var mockRepo = new Mock<IUserRepo>();
            mockRepo.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new User());
            var mockCont = new UserController(mockRepo.Object);
            ActionResult actionResult = mockCont.UpdateUser("testemail", "testusername", "testfirstname", "testlastname");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
    }
}