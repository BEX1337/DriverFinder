using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DriverFinder.Core
{
    public class BruteForceSortFinder : INearestDriverFinder // 1. Метод полного перебора и сортировки
    {
        public IReadOnlyList<Driver> FindTop5(Driver[] allDrivers, Point order)
        {
            return allDrivers
                .OrderBy(d => d.DistanceSquaredTo(order.X, order.Y)) // Сортируем по наименьшему расстоянию
                .Take(5) // Оставляем 5 водителей
                .ToList(); // Приводим к списку
        }
    }
}
