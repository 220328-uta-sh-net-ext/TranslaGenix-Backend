using DL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace TranslaGenixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepo repo;
        private static List<User> users = new List<User>();
        public UserController(IUserRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Route("Get All Users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<User>> Get()
        {
            try
            {
                users = repo.GetAllUsers();
            }
            catch (Exception ex)
            {
                //Log.Information("Bad Request exception @ Get User in UserC.");
                return BadRequest(ex.Message);
            }
            //Log.Information("Good request @ Get User in Userc.");
            return Ok(users);
        }
        [HttpPost]
        [Route("Add User")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddNewUser([FromQuery][BindRequired] User user)
        {
            //Try to add a new user
            try
            {
                repo.AddUser(user);
            }
            catch (Exception ex)
            {
                //Log.Information("Excetion occured in @ AddNewUser in UserC: " + ex);
                return BadRequest("Bad Request: " + ex);
            }
            //Log.Information("New user created w/ username: " + UserName + " @ AddNewUser in UserC");
            return CreatedAtAction("Get", user);
        }
    }
}
