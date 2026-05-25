using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DriverFinder.Core
{
    public class ArraySortFinder : INearestDriverFinder //Поиск с помощью Array.Sort
    {
        private const int CellSize = 50;

        public IReadOnlyList<Driver> FindTop5(Driver[] allDrivers, Point order)
        {
            var driversCopy = new Driver[allDrivers.Length];
            Array.Copy(allDrivers, driversCopy, allDrivers.Length);

            Array.Sort(driversCopy, (d1, d2) =>
            {
                double dist1 = d1.DistanceSquaredTo(order.X, order.Y);
                double dist2 = d2.DistanceSquaredTo(order.X, order.Y);

                if (dist1 < dist2) return -1;
                if (dist1 > dist2) return 1;
                return 0;
            });
            int count = Math.Min(5, driversCopy.Length);

            var result = new List<Driver>(count);
            for (int i = 0; i < count; i++)
            {
                result.Add(driversCopy[i]);
            }
            return result;
        }
    }
}