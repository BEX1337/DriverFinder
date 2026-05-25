using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DriverFinder.Core
{
    public class Driver
    {
        public string Id { get; }
        public int X { get; }
        public int Y { get; }
        
        public Driver(string id, int x, int y) 
        {
            Id = id;
            X = x;
            Y = y;
        }

        public double DistanceTo(int orderX, int orderY) // Стандартный способ вычисления расстояния
        {
            var dx = X - orderX;
            var dy = Y - orderY;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public double DistanceSquaredTo(int orderX, int orderY) // Упрощённый, без вычисления корня
        {
            var dx = X - orderX;
            var dy = Y - orderY;
            return dx * dx + dy * dy;
        }
    }
}
