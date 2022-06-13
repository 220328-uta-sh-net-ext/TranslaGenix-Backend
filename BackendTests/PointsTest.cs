using DL;
using FakeItEasy;
using Xunit;
using Models;
using TranslaGenixAPI.Controllers;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Net;

namespace BackendTests
{
    public class PointsTests
    {

        [Fact]
        public void Get_AllPoints()
        {
            var fakeContext = A.Fake<TGContext>();
            PointsRepo pr = new PointsRepo(fakeContext);

            var ret = pr.GetAllPoints();
            Assert.NotNull(ret);
        }

    }
}
