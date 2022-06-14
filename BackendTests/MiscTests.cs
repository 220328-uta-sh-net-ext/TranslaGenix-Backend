using DL;
using FakeItEasy;
using Xunit;
using Models;
using TranslaGenixAPI.Controllers;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackendTests
{
    public class MiscTests
    {
        [Fact]
        public void Test1()
        {
            var fakeContext = A.Fake<TGContext>();
            PointsRepo pr = new PointsRepo(fakeContext);
            var PointCheck = new PointsController(pr);
            Assert.NotNull(PointCheck);
        }
        [Fact]
        public async Task Test2()
        {
            var fakeContext = A.Fake<TGContext>();
            PointsRepo pr = new PointsRepo(fakeContext);
            var PointCheck = new PointsController(pr);
            Assert.NotNull(PointCheck);

        }
        [Fact]
        public void SimpleTest()
        {
            User newUser = new User();
            newUser.Username = "test";
            newUser.FirstName = "test";
            newUser.LastName = "test";
            newUser.Email = "test";
            newUser.Id = 1;

            Assert.Equal(1, newUser.Id);
        }
    }
}