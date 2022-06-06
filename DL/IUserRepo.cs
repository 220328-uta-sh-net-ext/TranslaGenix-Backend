using Models;

namespace DL
{
    public interface IUserRepo
    {
        User AddUser(User user);
        List<User> GetAllUsers();
        User GetUserByUserName(string UserName);
        User GetUserByFirstName(string FirstName);
        User GetUserByEmail(string Email);
        User Update(User user);
        void DeleteUser(int id);
    }
}
