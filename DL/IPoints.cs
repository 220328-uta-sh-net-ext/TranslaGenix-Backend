using EFPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IPoints
    {
        //Update by user name
        PointsSystem UpdatePoints(string name);
    }
}
