using System.Collections.Generic;
using System.Linq;

namespace DriverFinder.Core;
public class ManualTop5Finder : INearestDriverFinder
{
    public IReadOnlyList<Driver> FindTop5(Driver[] allDrivers, Point order)
    {
        var top5 = new List<Driver>();

        foreach (var driver in allDrivers)
        {
            double distance = driver.DistanceSquaredTo(order.X, order.Y);

            if (top5.Count < 5)
            {
                top5.Add(driver);
            }
            else
            {
                int farthestIndex = 0;
                double farthestDistance = top5[0].DistanceSquaredTo(order.X, order.Y);

                for (int i = 1; i < top5.Count; i++)
                {
                    double d = top5[i].DistanceSquaredTo(order.X, order.Y);
                    if (d > farthestDistance)
                    {
                        farthestDistance = d;
                        farthestIndex = i;
                    }
                }
                if (distance < farthestDistance)
                {
                    top5[farthestIndex] = driver;
                }
            }
        }
        return top5
            .OrderBy(d => d.DistanceSquaredTo(order.X, order.Y))
            .ToList();
    }
}