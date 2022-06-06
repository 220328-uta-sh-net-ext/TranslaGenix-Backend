using Models;

namespace DL
{
    public interface IUserRepo
    {
        User AddUser(User user);
        List<User> GetAllUsers();
        User GetUserByName(string name);
        User Update(User user);
        void DeleteUser(int id);
    }
}
