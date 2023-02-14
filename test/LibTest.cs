namespace test;
using lib;
public class LibTest
{
    class TriangleData : TheoryData<double[]>
    {
        public TriangleData()
        {
            Add(new double[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, -9, 1, -7, 5, 0, 7});
            Add(new double[] {0, 0, 0, 50, 0, 0, 0, 0, 50, 5, 0, 5, 5, 0, 10, 10, 0, 5});
            Add(new double[] {-11, 10, 0, 50, 0, 17, -9, 0, 50, -9, 0, 50, 15, 0, -10, 101, 78, 51});
            Add(new double[] {0, 1, 0, 1, 0, 20, 10, 0, 0, 1, 2, 3, -9, 1, 0, -1, -2, -3});
        }
    }
    [Theory]
    [ClassData(typeof(TriangleData))]
    public void TriangleAreIntersected(double[] arg)
    {
        bool actual = TestLib.AreIntersected(arg);
        Assert.True(actual);
    }


    class TriangleErrorData : TheoryData<double[]>
    {
        public TriangleErrorData()
        {
            Add(new double[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 2, 3, -9, 1, -7, 5, 0, 7});
            Add(new double[] {0, 50, 0, 50, 100, 0, -90, 0, 50, 5, 0, 5, 5, 0, 10, 10, 0, 5});
            Add(new double[] {0, 0, 0, 1, 0, 0, 10, 0, 0, 1, 2, 3, -9, 1, -7, 5, 0, 7});
            
        }
    }
    [Theory]
    [ClassData(typeof(TriangleErrorData))]
    public void TriangleAreNotIntersected(double[] arg)
    {
        bool actual = TestLib.AreIntersected(arg);
        Assert.False(actual);
    }
}
