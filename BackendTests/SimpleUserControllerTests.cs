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
    public class SimpleUserControllerTests
    {
        [Fact]
        public async Task Test1()
        {
            /*int count = 3;
            var fakeUsers = A.CollectionOfDummy<SimpleUser>(count).AsEnumerable();
            var dataStore = A.Fake<ISimpleUserRepo>();
            //A.CallTo(() => dataStore.GetAllSimpleUsers().Returns(Task.FromResult(fakeUsers));
            SimpleUserController controller = new SimpleUserController(dataStore);

            //var actionResult = controller.;

            var result = actionResult.Result as OkObjectResult;
            var returndata = result.Value as List<SimpleUser>;
            Assert.Equal(count, returndata.Count);*/
            var fakeContext = A.Fake<TGContext>();
            PointsRepo pr = new PointsRepo(fakeContext);
            var PointCheck = new PointsController(pr);
            Assert.NotNull(PointCheck);

        }
    }
}
