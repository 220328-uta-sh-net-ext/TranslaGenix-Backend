using Models;

namespace DL
{
    public interface IPointsRepo
    {
        Point AddPoint(Point point);
        List<Point> GetAllPoints();
        Point GetHighestPoint();
        Point GetPointById(int id);
        Point GetPointByUserName(string UserName);
        Point UpdatePoints(Point point);
        Point IncreasePointsById(int id);
        Point IncreasePointsByUserName(string username);
        void DeletePointbyID(int id);
        void DeletePointbyUserName(string name);
    }
}
