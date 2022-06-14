using DL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace TranslaGenixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private IPointsRepo repo;
        private static List<Point> points = new List<Point>();
        public PointsController(IPointsRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("GetAllPoints")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            try
            {
                points = repo.GetAllPoints();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(points);
        }

        [HttpPost]
        [Route("AddPoints")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult AddPoint([FromQuery][BindRequired] Point point)
        {

            try
            {
                repo.AddPoint(point);
            }
            catch (Exception ex)
            {

                return BadRequest("Bad Request: " + ex);
            }

            return CreatedAtAction("Get", point);
        }

        [HttpGet]
        [Route("GetHighstPoint")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult GetHighestPoint()
        {
            Point newPoint = new Point();
            try
            {
                newPoint = repo.GetHighestPoint();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(newPoint);
        }
        [HttpGet]
        [Route("GetPointByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetPointById(int id)
        {
            try
            {
                var filteredid = repo.GetPointById(id);
                return Ok(filteredid);
            }
            catch (Exception ex)
            {
                return BadRequest($"{id} is not in the database");
            }
        }
        [HttpGet]
        [Route("GetPointByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetPointByUserName(string UserName)
        {
            try
            {
                var filteredid = repo.GetPointByUserName(UserName);
                return Ok(filteredid);
            }
            catch (Exception ex)
            {
                return BadRequest($"{UserName} is not in the database");
            }
        }
        [HttpPut]
        [Route("UpdatePoints")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdatePoints(string name, int addpoint)
        {
            try
            {

                var pointAdd = repo.GetPointByUserName(name);
                pointAdd.Points += addpoint;

                var ret = repo.UpdatePoints(pointAdd);

            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok("Points has been updated");
        }

        [HttpPut]
        [Route("IncreasePointsById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IncreasePointsById(int id)
        {
            try
            {
                repo.IncreasePointsById(id);

            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok("1 Point has been Addedd");
        }

        [HttpPut]
        [Route("IncreasePointsByFirstName")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IncreasePointsByUserName(string username)
        {
            try
            {
                repo.IncreasePointsByUserName(username);

            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok("1 Point has been Addedd");
        }

        [HttpDelete]
        [Route("DeletePointsbyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeletePointbyID(int Id)
        {
            try
            {
                repo.DeletePointbyID(Id);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok($" {Id} is deleted");
        }

        [HttpDelete]
        [Route("DeletePointsByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeletePointbyUserName(string name)
        {
            try
            {
                repo.DeletePointbyUserName(name);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok($" {name} is deleted");
        }

        [HttpGet]
        [Route("GetLeaderboard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        public ActionResult GetLeaderBoard()
        {
            List<Point> listofpoints = new List<Point>();
            try
            {
                listofpoints = repo.GetAllPoints();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            if (listofpoints.Count == 0)
                return BadRequest("No data in points");
            listofpoints.Sort(delegate (Point p1, Point p2)
            {
                return p2.Points.CompareTo(p1.Points);
            });
            var leaderboard = new List<LeaderBoard>();
            foreach (Point p in listofpoints)
            {
                var val = new LeaderBoard();
                val.Name = repo.getUserNameByPoints(p);
                val.point = p.Points;
                leaderboard.Add(val);
            }
            return Ok(leaderboard);
        }
    }

}
