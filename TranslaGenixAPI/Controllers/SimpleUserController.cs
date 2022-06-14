/*using DL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace TranslaGenixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleUserController : ControllerBase
    {
        private ISimpleUserRepo repo;
        private static List<SimpleUser> users = new List<SimpleUser>();
        public SimpleUserController(ISimpleUserRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Route("GetAllSimpleUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<User>> Get()
        {
            try
            {
                users = repo.GetAllSimpleUsers();
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
        [Route("AddSimpleUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddNewUser([FromQuery][BindRequired] SimpleUser user)
        {
            //Try to add a new user
            try
            {
                await repo.AddUser(user);
            }
            catch (Exception ex)
            {
                //Log.Information("Excetion occured in @ AddNewUser in UserC: " + ex);
                return BadRequest("Bad Request: " + ex);
            }
            //Log.Information("New user created w/ username: " + UserName + " @ AddNewUser in UserC");
            return CreatedAtAction("Get", user);
        }
        [HttpDelete]
        [Route("DeleteSimpleUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> DeleteUser(string username)
        {
            var deleteduser = new User();
            try
            {
                await repo.DeleteSimpleUser(username);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok($"{username} has been deleted from the database");
        }
    }
}
*/