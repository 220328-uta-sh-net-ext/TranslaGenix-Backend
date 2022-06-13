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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void Add_point()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockRepo.Setup(x => x.AddPoint(new Point())).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.AddPoint(mockPoint);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
        [Fact]
        public void Get_HighestPoint()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockRepo.Setup(x => x.GetHighestPoint()).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetHighestPoint();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void Get_PointById()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.GetPointById(It.IsAny<int>())).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetPointById(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        /*[Fact]
        public void Get_PointByUserName()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.GetPointById(It.IsAny<int>())).Returns(mockPoint);
            mockRepo.Setup()
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetPointById(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }*/
    }
}
