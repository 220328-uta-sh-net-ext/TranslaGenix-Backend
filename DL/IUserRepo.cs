using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPractice.Models;
namespace DL
{
    public interface IUserRepo
    {
        //Add User
        UserProfile AddUser(UserProfile user);
        //Update User
        UserProfile UpdateUser(UserProfile user);
    }
}
