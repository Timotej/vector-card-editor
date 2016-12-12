using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorCardEditor
{
    public static class Helpers
    {
        public static bool IsBetween(double value, double min, double max)
        {
            return value >= min && value <= max;     
        }
    }
}
