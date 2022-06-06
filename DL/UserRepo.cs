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
            Point newPoint = new Point();
            newPoint.userId = user.Id;
            newPoint.Points = 0;
            db.points.Add(newPoint);
            db.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var deletethis = db.users.Where(u => u.Id == id).FirstOrDefault();
            if (deletethis != null)
            {
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

        public User Update(User user)
        {
            db.users.Update(user);
            db.SaveChanges();
            return user;
        }
    }
}
