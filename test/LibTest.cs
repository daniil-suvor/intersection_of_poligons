namespace test;

using lib;

public class LibTest
{
    class TriangleData : TheoryData<double[], bool>
    {
        public TriangleData()
        {
            Add(new double[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, -9, 1, -7, 5, 0, 7}, true);
            Add(new double[] {0, 0, 0, 50, 0, 0, 0, 0, 50, 5, 0, 5, 5, 0, 10, 10, 0, 5}, true);
            Add(new double[] {-11, 10, 0, 50, 0, 17, -9, 0, 50, -9, 0, 50, 15, 0, -10, 101, 78, 51}, true);
            Add(new double[] {0, 1, 0, 1, 0, 20, 10, 0, 0, 1, 2, 3, -9, 1, 0, -1, -2, -3}, true);

            Add(new double[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 2, 3, -9, 1, -7, 5, 0, 7}, false);
            Add(new double[] {0, 50, 0, 50, 100, 0, -90, 0, 50, 5, 0, 5, 5, 0, 10, 10, 0, 5}, false);
            Add(new double[] {0, 0, 0, 1, 0, 0, 10, 0, 0, 1, 2, 3, -9, 1, -7, 5, 0, 7}, false);

        }
    }
    [Theory]
    [ClassData(typeof(TriangleData))]
    public void TriangleAreIntersected(double[] arg, bool expected)
    {
        bool actual = TestLib.AreIntersected(arg);
        Assert.Equal(expected, actual);
    }
}
