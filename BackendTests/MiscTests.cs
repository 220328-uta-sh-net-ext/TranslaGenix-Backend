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
        public void UserTest()
        {
            User newUser = new User();
            newUser.Username = "test";
            newUser.FirstName = "test";
            newUser.LastName = "test";
            newUser.Email = "test";
            newUser.Id = 1;

            Assert.Equal(1, newUser.Id);
        }

        [Fact]
        public void LeaderBoardTest()
        {
            LeaderBoard l = new LeaderBoard();
            l.Name = "Test";
            l.point = 0;
            Assert.Equal(0, l.point);
        }

        [Fact]
        public void JsonInputTest()
        {
            JsonInput j = new JsonInput();
            j.eventType = null;
            j.eventTypeVersion = null;
            j.cloudEventsVersion = null;
            j.source = null;
            j.eventId = null;
            j.contentType = null;
            j.data = new Data();
            /*j.data.events.Add(new Event());
            j.data.events[0].uuid = null;
            j.data.events[0].published = null;
            j.data.events[0].eventType = null;
            j.data.events[0].version = null;
            j.data.events[0].displayMessage = null;
            j.data.events[0].severity = null;
            j.data.events[0].client = new Client();
            j.data.events[0].device = null;
            j.data.events[0].actor = new Actor();
            j.data.events[0].target.Add(new Target());
            j.data.events[0].transaction = new Transaction();*/
            Assert.Equal(null, j.eventType);
        }
    }
}