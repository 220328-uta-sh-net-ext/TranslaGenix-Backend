using Models;

namespace DL
{
    public interface ISimpleUserRepo
    {
        Task<SimpleUser> AddUser(SimpleUser user);
        List<SimpleUser> GetAllSimpleUsers();
        Task DeleteSimpleUser(string UserName);
    }
}
