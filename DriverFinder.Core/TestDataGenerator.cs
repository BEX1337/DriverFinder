using System;
using System.Collections.Generic;
using System.Text;

namespace DriverFinder.Core
{
    public static class TestDataGenerator //Создаёт случайных водителей
    {
        public static Driver[] Generate(int count, int maxX, int maxY, int seed = 13)
        {
            var random = new Random(seed);
            var drivers = new Driver[count];
            for (int i = 0; i < count; i++)
            {
                int x = random.Next(0, maxX);
                int y = random.Next(0, maxY);
                drivers[i] = new Driver($"driver_{i}", x, y);
            }
            return drivers;
        }
    }
}
