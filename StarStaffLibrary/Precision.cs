using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarStaffLibrary
{
    public class Precision
    {
        private readonly double Delta;

        public Precision(double delta)
        {
            if (Double.IsInfinity(delta))
                throw new ArgumentException("delta is not finite");
            if (delta < 0)
                throw new ArgumentException("delta should be non-negative");

            this.Delta = delta;
        }

        public double GetDelta()
        {
            return Delta;
        }

        public bool LessOrEqualUnchecked(double a, double b)
        {
            return (a <= b + Delta);
        }

        public bool LessUnchecked(double a, double b)
        {
            return (a < b + Delta);
        }

        public bool NonZeroUnchecked(double a)
        {
            return (Math.Abs(a) > Delta);
        }
    }
}
