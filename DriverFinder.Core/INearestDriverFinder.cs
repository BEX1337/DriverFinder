using System;
using System.Collections.Generic;
using System.Text;

namespace DriverFinder.Core
{
    public interface INearestDriverFinder
    {
        IReadOnlyList<Driver> FindTop5(Driver[] allDrivers, Point order);
    }
}
