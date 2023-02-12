namespace test;
using vector;
using triangle;
public class TriangleTest
{
    [Fact]
    public void Test1() {
        Vector pointA = new Vector(1, 0, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 0, 1);
        Triangle trg = new Triangle(pointA, pointB, pointC);

        Vector checkPoint = new Vector(0.1, 0, 0.1);

        bool expected = true;
        bool actual = trg.poinInTriangle(checkPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test2() {
        Vector pointA = new Vector(1, 0, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 0, 1);
        Triangle trg = new Triangle(pointA, pointB, pointC);

        Vector checkPoint = new Vector(0.5, 0, 0.5);

        bool expected = true;
        bool actual = trg.poinInTriangle(checkPoint);

        Assert.Equal(expected, actual);
    }
}
