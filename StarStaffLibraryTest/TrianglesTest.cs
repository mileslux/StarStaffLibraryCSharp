using System;
using System.Collections;
using NUnit.Framework;
using StarStaffLibrary;

namespace StarStaffLibraryTest
{
    [TestFixture]
    public class TrianglesTest
    {
        public const double DELTA = 1e-8;
        public static readonly Precision Precision = new Precision(DELTA);
        public static readonly Triangles Triangles = new Triangles(Precision);

        [Test, TestCaseSource(typeof(TrianglesTestData), "RightAngledTriangleAreaValid")]
        public void TestRightAngledTriangleAreaValid(double a, double b, double c, double expected)
        {
            Assert.AreEqual(expected, Triangles.AreaRightAngledTriangle(a, b, c), DELTA);
        }

        [Test, TestCaseSource(typeof(TrianglesTestData), "RightAngledTriangleAreaInvalid")]
        public void TestRightAngledTriangleAreaInvalid(double a, double b, double c)
        {
            Assert.That(() => Triangles.AreaRightAngledTriangle(a, b, c), Throws.TypeOf<ArgumentException>());
        }

        public class TrianglesTestData
        {
            public static IEnumerable RightAngledTriangleAreaValid
            {
                get
                {
                    yield return new TestCaseData(3, 4, 5, 6);
                    yield return new TestCaseData(13, 12, 5, 30);
                    yield return new TestCaseData(40, 9, 41, 180);
                    yield return new TestCaseData(0.7, 2.5, 2.4, 0.84);
                    yield return new TestCaseData(1, 1, 1.41421356, 0.5);
                    yield return new TestCaseData(1.4142135623, 1.7320508075, 2.236067977, 1.2247448713);
                }
            }

            public static IEnumerable RightAngledTriangleAreaInvalid
            {
                get
                {
                    yield return new TestCaseData(Double.NaN, 1, 1);
                    yield return new TestCaseData(1, Double.NegativeInfinity, 1);
                    yield return new TestCaseData(1, 1, Double.PositiveInfinity);
                    yield return new TestCaseData(-1, 1, 1);
                    yield return new TestCaseData(1, 0, 1);
                    yield return new TestCaseData(4, 3, 1);
                    yield return new TestCaseData(3, 4, 6);
                    yield return new TestCaseData(1, 1, 1.4142135);
                }
            }
        }
    }
}