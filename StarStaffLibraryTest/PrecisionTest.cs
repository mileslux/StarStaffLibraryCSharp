using System;
using System.Collections;
using NUnit.Framework;
using StarStaffLibrary;

namespace StarStaffLibraryTest
{
    [TestFixture]
    public class PrecisionTest
    {
        public const double DELTA = 1e-8;
        public readonly static Precision Precision = new Precision(DELTA);

        [Test, TestCaseSource(typeof(TrianglesTestData), "LessOrEqualUnchecked")]
        public void TestLessOrEqualUnchecked(double a, double b, bool expected) {
            Assert.AreEqual(expected, Precision.LessOrEqualUnchecked(a, b));
        }

        [Test, TestCaseSource(typeof(TrianglesTestData), "LessUnchecked")]
        public void TestLessUnchecked(double a, double b, bool expected) {
            Assert.AreEqual(expected, Precision.LessUnchecked(a, b));
        }

        [Test, TestCaseSource(typeof(TrianglesTestData), "NonZeroUnchecked")]
        public void TestNonZeroUnchecked(double a, bool expected) {
            Assert.AreEqual(expected, Precision.NonZeroUnchecked(a));
        }

        public class TrianglesTestData
        {
            public static IEnumerable LessOrEqualUnchecked
            {
                get
                {
                    yield return new TestCaseData(1, 1, true);
                    yield return new TestCaseData(1 + DELTA, 1, true);
                    yield return new TestCaseData(1 + DELTA * 1.1, 1, false);
                }
            }

            public static IEnumerable LessUnchecked
            {
                get
                {
                    yield return new TestCaseData(1, 1, true);
                    yield return new TestCaseData(1 + DELTA, 1, false);
                    yield return new TestCaseData(1 + DELTA / 2 , 1, true);
                }
            }

            public static IEnumerable NonZeroUnchecked
            {
                get
                {
                    yield return new TestCaseData(1, true);
                    yield return new TestCaseData(DELTA * 1.1, true);
                    yield return new TestCaseData(DELTA, false);
                    yield return new TestCaseData(0, false);
                }
            }
        }
    }
}
