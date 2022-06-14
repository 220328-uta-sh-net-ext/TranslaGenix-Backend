using DL;
using Models;
using TranslaGenixAPI.Controllers;
using System.Collections.Generic;
using Moq;

using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BackendTests
{
    public class PointsTests
    {
        [Fact]
        public void GetAllPointsTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            mockRepo.Setup(x => x.GetAllPoints()).Returns(new List<Point>());
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.Get();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void AddpointTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockRepo.Setup(x => x.AddPoint(new Point())).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.AddPoint(mockPoint);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
        [Fact]
        public void GetHighestPointTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockRepo.Setup(x => x.GetHighestPoint()).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetHighestPoint();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void GetPointByIdTest()
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

        [Fact]
        public void GetPointByUserNameTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.GetPointByUserName(It.IsAny<string>())).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetPointByUserName("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void UpdatePointsTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.UpdatePoints(mockPoint)).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.UpdatePoints("test", 5);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void IncreasePointsByIdTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.IncreasePointsById(It.IsAny<int>())).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.IncreasePointsById(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void IncreasePointsByUserNameTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.IncreasePointsByUserName(It.IsAny<string>())).Returns(mockPoint);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.IncreasePointsByUserName("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void DeletePointbyIDTest()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.DeletePointbyID(It.IsAny<int>()));
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.DeletePointbyID(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void DeletePointbyUserName()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var mockPoint = new Point();
            mockPoint.Id = 1;
            mockPoint.userId = 1;
            mockPoint.Points = 0;
            mockRepo.Setup(x => x.DeletePointbyUserName(It.IsAny<string>()));
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.DeletePointbyUserName("test");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }

        [Fact]
        public void GetLeaderBoard()
        {
            var mockRepo = new Mock<IPointsRepo>();
            var pointL = new List<Point>();
            var mockPoint = new Point();
            mockRepo.Setup(x => x.GetAllPoints()).Returns(pointL);
            var mockCont = new PointsController(mockRepo.Object);
            ActionResult actionResult = mockCont.GetLeaderBoard();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(actionResult);
        }
    }
}
