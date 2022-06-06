using Models;

namespace DL
{
    public interface IPointsRepo
    {
        /// <summary>
        /// Adds a new Point variable to the DB
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Returns the point vriable that was made</returns>
        Point AddPoint(Point point);
        /// <summary>
        /// Gets all point variables in the DB
        /// </summary>
        /// <returns>A list of all point variables</returns>
        List<Point> GetAllPoints();
        /// <summary>
        /// Gets the point variable with the highest number of points from the DB.
        /// Doesn't split between ties. Just returns the first one found with the highest.
        /// </summary>
        /// <returns>A point variable with the greatest value in Points.</returns>
        Point GetHighestPoint();
        /// <summary>
        /// Takes in a user's ID to return the associated Point structure.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A point variable with a matching ID. Null if not found.</returns>
        Point GetPointById(int id);
        /// <summary>
        /// Takes in a user's UserName to return the associated Point structure.
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns>A point variable with a matching UserName. Null if not found.</returns>
        Point GetPointByUserName(string UserName);
        /// <summary>
        /// Updates an exisiting Point strcture within the DB.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>A point variable that had been updated. Null if not found.</returns>
        Point UpdatePoints(Point point);
        /// <summary>
        /// Increases Points by 1. Adds that to a point variable which is updated.
        /// Finds the point variable to update by the associated ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns Null if not found. Returns updated Point strcture if it works.</returns>
        Point IncreasePointsById(int id);
        /// <summary>
        /// Increases Points by 1. Adds that to a point variable which is updated.
        /// Finds the point variable to update by the associated UserName to the points 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns Null if not found. Returns updated Point strcture if it works.</returns>
        Point IncreasePointsByUserName(string username);
        /// <summary>
        /// Deletes Point Variable by associated ID
        /// </summary>
        /// <param name="id"></param>
        void DeletePointbyID(int id);
        /// <summary>
        /// Deletes Point Vairable by associated username
        /// </summary>
        /// <param name="name"></param>
        void DeletePointbyUserName(string name);
    }
}
