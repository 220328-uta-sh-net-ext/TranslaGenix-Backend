using Models;

namespace DL
{
    public class UserRepo: IUserRepo
    {
        private TGContext db;
        public UserRepo(TGContext db)
        {
            this.db = db;
        }
        public User AddUser(User user)
        {
            db.users.Add(user);
            db.SaveChanges();
            Point newPoint = new Point();
            newPoint.userId = user.Id;
            newPoint.Points = 0;
            db.points.Add(newPoint);
            db.SaveChanges();
            return user;
        }

        public void DeleteUser(string UserName)
        {
            var deletethis = db.users.Where(u => u.Username == UserName).FirstOrDefault();
            if (deletethis != null)
            {
                var deletePoint = db.points.Where(a => a.userId == deletethis.Id).FirstOrDefault();
                if(deletePoint != null)
                    db.points.Remove(deletePoint);
                db.users.Remove(deletethis);
                db.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            return db.users.ToList();
        }

        public User GetUserByUserName(string UserName)
        {
            return db.users.Where(u => u.Username == UserName).FirstOrDefault();
        }

        public User GetUserByFirstName(string FirstName)
        {
            return db.users.Where(u => u.FirstName == FirstName).FirstOrDefault();
        }
        public User GetUserByEmail(string email)
        {
            return db.users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User Update(string email, string newusername, string newFirstName, string newLastName)
        {
            var _user = db.users.FirstOrDefault(u => u.Email == email);
            if (_user != null)
            {
                if(newFirstName != null && newFirstName != "")
                    _user.FirstName = newFirstName;
                if (newLastName != null && newLastName != "")
                    _user.LastName = newLastName;
                if (newusername != null && newusername != "")
                    _user.Username = newusername;
                db.users.Update(_user);
                db.SaveChanges();
            }
            return _user;
        }

        public User Update()
        {
            throw new NotImplementedException();
        }
    }
}
