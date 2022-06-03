using EFPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserRepo : IUserRepo
    {
        private Context db;

        public UserRepo (Context db)
        {
            this.db = db;
        }

        public UserProfile AddUser(UserProfile user)
        {
            db.users.Add(user);
            db.SaveChanges();
            return user;
        }

        public UserProfile UpdateUser(UserProfile user)
        {
            db.users.Update(user);
            db.SaveChanges();
            return user;
        }
    }
}
