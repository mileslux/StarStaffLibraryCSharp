using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarStaffLibrary
{
    public class Triangles
    {
        private readonly Precision Precision;

        public Triangles(Precision precision)
        {
            this.Precision = precision;
        }

        public Precision getPrecision()
        {
            return Precision;
        }

        public double areaRightAngledTriangle(double a, double b, double c)
        {
            if (Double.IsNaN(a))
                throw new ArgumentException("First argument is NaN");
            if (Double.IsNaN(b))
                throw new ArgumentException("Second argument is not NaN");
            if (Double.IsNaN(c))
                throw new ArgumentException("Third argument is not NaN");

            if (Double.IsInfinity(a))
                throw new ArgumentException("First argument is not finite");
            if (Double.IsInfinity(b))
                throw new ArgumentException("Second argument is not finite");
            if (Double.IsInfinity(c))
                throw new ArgumentException("Third argument is not finite");

            if (Precision.LessOrEqualUnchecked(a, 0))
                throw new ArgumentException("First argument should be positive");
            if (Precision.LessOrEqualUnchecked(b, 0))
                throw new ArgumentException("Second argument should be positive");
            if (Precision.LessOrEqualUnchecked(c, 0))
                throw new ArgumentException("Third argument should be positive");

            if (Precision.LessOrEqualUnchecked(a + b, c) ||
                    Precision.LessOrEqualUnchecked(a + c, b) ||
                    Precision.LessOrEqualUnchecked(b + c, a))
                throw new ArgumentException("Triangle inequality is violated");

            double swap;

            if (Precision.LessUnchecked(c, a))
            {
                swap = a;
                a = c;
                c = swap;
            }

            if (Precision.LessUnchecked(c, b))
            {
                swap = b;
                b = c;
                c = swap;
            }

            if (Precision.NonZeroUnchecked(c * c - a * a - b * b))
                throw new ArgumentException("Triangle is not right-angled");

            return a * b / 2;
        }
    }
}
