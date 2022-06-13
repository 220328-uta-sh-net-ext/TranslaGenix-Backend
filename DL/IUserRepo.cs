using Models;

namespace DL
{
    public interface IUserRepo
    {
        /// <summary>
        /// Adds a new user object to the DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the user object added to the DB</returns>
        User AddUser(User user);
        /// <summary>
        /// Gets all of the users in the DB
        /// </summary>
        /// <returns>A list of all users in the database</returns>
        List<User> GetAllUsers();
        /// <summary>
        /// Gets a user by a specific UserName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns>Returns a user found by their UserName. Returns null otherwise.</returns>
        User GetUserByUserName(string UserName);
        /// <summary>
        /// Gets a user by a specific First Name
        /// </summary>
        /// <param name="FirstName"></param>
        /// <returns>Returns a user found by their FirstName. Returns null otherwise.</returns>
        User GetUserByFirstName(string FirstName);
        /// <summary>
        /// Gets a user by a specific Email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>Returns a user found by their email. Returns null otherwise.</returns>
        User GetUserByEmail(string Email);
        /// <summary>
        /// Updates an exisiting user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the information that was used to update a user</returns>
        User Update(string email, string newusername, string newFirstName, string newLastName);
        /// <summary>
        /// Removes a user by ID from the DB
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(string UserName);
    }
}
