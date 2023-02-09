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
    public void VectorEqualTest()
    {
        Vector v1 = new Vector(2, 0, -2);
        Vector v2 = new Vector(2, 0, -2);
        bool actual = v1 == v2;
        bool expected = true;
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorNotEqualTest()
    {
        Vector v1 = new Vector(0, 0, 0);
        Vector v2 = new Vector(0, 0, -2);
        bool actual = v1 == v2;
        bool expected = true;
        Assert.NotEqual(actual, expected);
    }
    [Fact]
    public void VectorTwoDotsEqualTest()
    {
        Vector v1 = new Vector(0, 10, -4, 0, 9, -5);
        Vector v2 = new Vector(0, 5, -2, 0, 4, -3);
        bool actual = v1 == v2;
        bool expected = true;
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorNormaTest()
    {
        Vector v1 = new Vector(4, 0, 3);
        double actual = v1.norma();
        double expected = 5;
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorCos180Test()
    {
        Vector v1 = new Vector(4, 0, 3);
        Vector v2 = new Vector(-4, 0, -3);
        double actual = v1.cos(v2);
        double expected = -1;
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorCos0Test()
    {
        Vector v1 = new Vector(4, 9, 3);
        Vector v2 = new Vector(20, 45, 15);
        double actual = v1.cos(v2);
        double expected = 1;
        Assert.Equal(actual, expected);
    }
}