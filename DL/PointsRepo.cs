using Models;

namespace DL
{
    public class PointsRepo : IPointsRepo
    {
        private TGContext db;
        public PointsRepo(TGContext db)
        {
            this.db = db;
        }
        public Point AddPoint(Point point)
        {
            db.points.Add(point);
            db.SaveChanges();
            return point;
        }

        public void DeletePointbyID(int id)
        {
            var deletethis = db.points.Where(u => u.Id == id).FirstOrDefault();
            if (deletethis != null)
            {
                db.points.Remove(deletethis);
                db.SaveChanges();
            }
        }

        public void DeletePointbyUserName(string name)
        {
            var deletethis = db.users.Where(u => u.Username == name).FirstOrDefault();
            if (deletethis == null)
                return;
            var deletePoints = db.points.Where(u => u.Id == deletethis.Id).FirstOrDefault();
            if (deletethis != null)
            {
                db.points.Remove(deletePoints);
                db.SaveChanges();
            }
        }

        public List<Point> GetAllPoints()
        {
            return db.points.ToList();
        }

        public Point GetHighestPoint()
        {
            int greatest = -1;
            Point greatestPoint = new Point();
            foreach(Point p in db.points)
            {
                if (p.Points > greatest)
                {
                    greatest = p.Points;
                    greatestPoint = p;
                }
            }
            if (greatestPoint == new Point())
                return default;
            return greatestPoint;
        }

        public Point GetPointById(int id)
        {
            return db.points.Where(u => u.Id == id).FirstOrDefault();
        }

        public Point GetPointByUserName(string UserName)
        {
            //changed to be by firstname instead
            var temp = db.users.Where(u => u.FirstName == UserName).FirstOrDefault();
            if (temp != null)
            {
                var point = db.points.Where(u => u.userId == temp.Id).FirstOrDefault();
                if (point != null)
                {
                    point.Points += 1;
                    return UpdatePoints(point);
                }
                return default;
            }
            return default;
        }

        public Point IncreasePointsById(int id)
        {
            var temp = db.points.Where(u => u.userId == id).FirstOrDefault();
            if (temp != null)
            {
                temp.Points += 1;
                return UpdatePoints(temp);
            }
            return default;
        }

        public Point IncreasePointsByUserName(string UserName)
        {
            var tempUser = db.users.Where(u => u.Username == UserName).FirstOrDefault();
            if (tempUser == null)
                return default;
            var tempPoints = db.points.Where(u => u.Id == tempUser.Id).FirstOrDefault();
            if (tempPoints != null)
            {
                tempPoints.Points += 1;
                return UpdatePoints(tempPoints);
            }
            return default;
        }

        public Point UpdatePoints(Point point)
        {
            db.points.Update(point);
            db.SaveChanges();
            return point;
        }

        public string getUserNameByPoints(Point point)
        {
            return db.users.Where(u => u.Id == point.userId).FirstOrDefault().Username;
        }
    }
}
