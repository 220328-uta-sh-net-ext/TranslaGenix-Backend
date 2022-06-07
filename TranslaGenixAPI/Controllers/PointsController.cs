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
        private IUserRepo userRepo;
        private static List<Point> points = new List<Point>();
        public PointsController(IPointsRepo repo, IUserRepo userRepo)
        {
            this.repo = repo;
            this.userRepo = userRepo;
        }

        [HttpGet]
        [Route("Get All Points")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<List<Point>> Get()
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
        [Route("Add Points")]
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
        [Route("Get Highst Point")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult <Point> GetHighestPoint()
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
        [Route("Get Point by ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Point>> GetPointById(int id)
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
        [Route("Get Point by User Name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Point>> GetPointByUserName(string UserName)
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
        [Route("Update Points")]
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
        [Route("Increase Points By Id")]
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
        [Route("Increase Points By UserName")]
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
        [Route("Delete Points by Id")]
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
        [Route("Delete Points by User Name")]
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
    }

}
