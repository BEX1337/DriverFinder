using System;
using System.Collections.Generic;
using System.Text;

namespace DriverFinder.Core
{
    public class HeapBasedFinder : INearestDriverFinder //Сортировка с помощью PriorityQueue
    {
        public IReadOnlyList<Driver> FindTop5(Driver[] allDrivers, Point order)
        {
            var queue = new PriorityQueue<Driver, double>();

            foreach (var driver in allDrivers)
            {
                double distance = driver.DistanceSquaredTo(order.X, order.Y);
                
                if (queue.Count < 5)
                {
                    queue.Enqueue(driver, -distance);
                }
                else
                {
                    var worstPriority = queue.UnorderedItems
                        .OrderByDescending(x => x.Priority)
                        .First().Priority;
                    if (distance < -worstPriority)
                    {
                        queue.EnqueueDequeue(driver, -distance);
                    }
                }
            }
            var result = new List<Driver>();
            while (queue.Count > 0)
            {
                result.Add(queue.Dequeue());
            }
            result.Reverse();
            return result;
        }
    }
}
