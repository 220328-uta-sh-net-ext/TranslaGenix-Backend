using Models;

namespace DL
{
    public interface ISimpleUserRepo
    {
        SimpleUser AddUser(SimpleUser user);
        List<SimpleUser> GetAllSimpleUsers();
        void DeleteSimpleUser(string UserName);
    }
}
