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
        

    }

}
