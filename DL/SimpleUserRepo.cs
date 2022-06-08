using Models;

namespace DL
{
    public class SimpleUserRepo : ISimpleUserRepo
    {
        private TGContext db;
        public SimpleUserRepo(TGContext db)
        {
            this.db = db;
        }
        public SimpleUser AddUser(SimpleUser user)
        {
            db.simpleUserList.Add(user);
            db.SaveChanges();
            return user;
        }

        public void DeleteSimpleUser(string UserName)
        {
            var deletethis = db.simpleUserList.Where(u => u.Username == UserName).FirstOrDefault();
            if (deletethis == null)
                return;
            db.simpleUserList.Remove(deletethis);
            db.SaveChanges();
            return;
        }

        public List<SimpleUser> GetAllSimpleUsers()
        {
            return db.simpleUserList.ToList();
        }
    }
}
