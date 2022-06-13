using DL;
using Models;
using TranslaGenixAPI.Controllers;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BackendTests
{
    public class PointsTests
    {
        [Fact]
        public void Get_AllPoints()
        {
            var mockRepo = new Mock<IPointsRepo>();
            mockRepo.Setup(x => x.GetAllPoints()).Returns(new List<Point>());

            var mockCont = new PointsController(mockRepo.Object);

            ActionResult actionResult = mockCont.Get();
            //var contentResult = actionResult as OkNegotiatedContentResult<Point>;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
    }
}
