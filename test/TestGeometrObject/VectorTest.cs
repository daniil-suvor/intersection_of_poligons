namespace test;
using vector;
public class VectorTest
{
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
    public void VectorZeroNormaTest()
    {
        Vector v1 = new Vector(0, 0, 0);
        double actual = v1.norma();
        double expected = 0;
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
    [Fact]
    public void VectorCos0_6Test()
    {
        Vector v1 = new Vector(3, 0, 0);
        Vector v2 = new Vector(3, 4, 0);
        double actual = v1.cos(v2);
        double expected = 0.6;
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorProd()
    {
        Vector v1 = new Vector(1, 0, 0);
        Vector v2 = new Vector(0, 1, 0);
        Vector actual = v1.vectorProd(v2);
        Vector expected = new Vector(0, 0, 1);
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorProd2()
    {
        Vector v1 = new Vector(1, 5, 6);
        Vector v2 = new Vector(8, 3, 4);
        Vector actual = v1.vectorProd(v2);
        Vector expected = new Vector(2, 44, -37);
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void CollinearityVectorProd()
    {
        Vector v1 = new Vector(6, -7, 5);
        Vector v2 = new Vector(-12, 14, -10);
        Vector actual = v1.vectorProd(v2);
        Vector expected = new Vector(0, 0, 0);
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorSum()
    {
        Vector actual = new Vector(-1, 8, -7) + new Vector(4, 1, 0) + new Vector(3, -4, 1);
        Vector expected = new Vector(6, 5, -6);
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorSub()
    {
        Vector actual = new Vector(-1, 8, -7) - new Vector(4, 1, 0) - new Vector(3, -4, 1);
        Vector expected = new Vector(-8, 11, -8);
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void VectorConstantProd()
    {
        Vector actual = new Vector(-1, 8, -7) * 3;
        Vector expected = new Vector(-3, 24, -21);
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void ConstantVectorProd()
    {
        Vector actual = -4 * new Vector(2, 0, -7);
        Vector expected = new Vector(-8, 0, 28);
        Assert.Equal(actual, expected);
    }
    [Fact]
    public void DivProd()
    {
        Vector actual = new Vector(2, 0, -7)/2;
        Vector expected = new Vector(1, 0, -3.5);
        Assert.Equal(actual, expected);
    }
}
