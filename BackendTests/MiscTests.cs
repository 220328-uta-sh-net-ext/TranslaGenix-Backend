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
    public class PointsControllerTests
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
    }
}