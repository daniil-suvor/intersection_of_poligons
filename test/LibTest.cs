namespace test;
using lib;
using vector;
public class LibTest
{
    [Fact]
    public void Test1() {
        double[] arg = {1,2,3,4,5,6};
        bool expected = true;
        bool actual = TestLib.AreIntersected(arg);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test2() {
        double[] arg = {1,2,3,-4,5,6};
        bool expected = false;
        bool actual = TestLib.AreIntersected(arg);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void VectorTest()
    {
        Vector v1 = new Vector(2, 2, 2);
        Vector v2 = new Vector(1, 2, 3);
        Vector v3 =  new Vector(1, 0, -1);
        Vector v4 = (v2 + v3);
        bool actual = v1 == v4;
        Assert.Equal(actual, true);
    }
}