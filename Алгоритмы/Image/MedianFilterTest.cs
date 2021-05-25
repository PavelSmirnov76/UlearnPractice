using NUnit.Framework;

namespace Recognizer
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCaseSource(nameof(Cases))]    
        public void Test(double[,] original, double[,] expectedMedian) 
        {
            var actualMedian = MedianFilterTask.MedianFilter(original);
            Assert.AreEqual(expectedMedian, actualMedian);
        }
        static object[] Cases =
        {
            new object[]
            {
                new double[,] {{1}},
                new double[,] {{1}}
            },
            new object[]
            {
                new double[,] {
                    {1, 2},
                    {4, 5}
                },
                new double[,] {
                    {3, 3},
                    {3, 3}
                }
            },
            new object[]
            {
                new double[,] {
                    {1, 3}
                },
                new double[,] {
                    {2, 2}
                }
            },
            new object[]
            {
                new double[,] {
                    {1},{3}
                },
                new double[,] {
                    {2},{2}
                }
            },
            new object[]
            {
                new double[,] {
                    {1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}
                },
                new double[,] {
                    {3, 3.5, 4},
                    {4.5, 5, 5.5},
                    {6, 6.5, 7}
                }
            }
        };
    }
}
