using DL;
using Microsoft.AspNetCore.Mvc;
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
        [Route("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get()
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
        [Route("userTransfer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddNewUser([FromBody] JsonInput? obj) //[FromQuery][BindRequired] User user
        {
            var events = obj.data.events;
            var c = events.FirstOrDefault();
            User newUser = new User();
            if(c != null)
            {
                var e = c.target.FirstOrDefault();
                if (e != null)
                {
                    string fullname = e.displayName;
                    string[] namesplit = fullname.Split(' ');
                    newUser.Username = fullname;
                    newUser.Email = e.alternateId;
                    newUser.FirstName = namesplit[0];
                    newUser.LastName = namesplit[1];
                }
                else
                {
                    return BadRequest("Issue with Json.");
                }   
            }
            else
            {
                return BadRequest("Issue with Json.");
            }
            try
            {
                repo.AddUser(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return CreatedAtAction("AddNewUser", newUser);
        }

        [HttpGet]
        [Route("GetUserByUsername")]
        [ProducesResponseType(200)]
        public ActionResult GetbyUsername(string username)
        {
            try
            {
                var filtereduser = repo.GetUserByUserName(username);
                return Ok(filtereduser);
            }
            catch (Exception ex)
            {
                return BadRequest($"User with username: {username} is not in the database");
            }
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        [ProducesResponseType(200)]
        public ActionResult GetbyEmail(string email)
        {
            try
            {
                var filteredemail = repo.GetUserByEmail(email);
                return Ok(filteredemail);
            }
            catch (Exception ex)
            {
                return BadRequest($"User with email: {email} is not in the database");
            }
        }

        [HttpGet]
        [Route("GetUserByFirstname")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult GetbyFirstname(string firstname)
        {
            try
            {
                var filteredfirstname = repo.GetUserByFirstName(firstname);
                return Ok(filteredfirstname);
            }
            catch (Exception ex)
            {
                return BadRequest($"User with firstname: {firstname} is not in the database");
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult DeleteUser(string username)
        {
            var deleteduser = new User();
            try
            {
                deleteduser = repo.GetUserByUserName(username);

                if (deleteduser == null)
                {
                    return NotFound($"{username} isn't in the database");
                }
                repo.DeleteUser(username);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok($" {username} has been deleted from the database");
        }

        [HttpPut]
        [Route("UpdateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult UpdateUser(string email, string? newusername, string? newFirstName, string? newLastName)
        {
            try
            {
                var updateduser = repo.Update(email, newusername, newFirstName, newLastName);
                return Ok(updateduser);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request: " + ex);
            }
            return Ok("user email has been updated");
        }
        /*
         * Used for 1 time Okta Connection
        [HttpGet]
        [Route("userTransfer")]
        [Produces("application/json")] //for Okta
        public ActionResult OktaGet([FromQuery] HttpRequestMessage request)
        {
            try
            {
                IEnumerable<string> headerValues = Request.Headers["x-okta-verification-challenge"];//GetValues("x-okta-verification-challenge");
                var response = headerValues.FirstOrDefault();
                if (response != null)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("verification", response);
                    return Ok(data);
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest(request);
            }
        }*/
    }
}
