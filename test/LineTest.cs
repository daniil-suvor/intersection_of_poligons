namespace test;
using line;
using vector;

public class LineTest
{
    [Fact]
    public void TestIntersected1() {
        Vector pointA1 = new Vector(0, 1, 1);
        Vector pointB1 = new Vector();
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(0, 5, 0);
        Vector pointB2 = new Vector(0, 4, 5);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = true;
        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestIntersected2() {
        Vector pointA1 = new Vector(-2, -1, 5);
        Vector pointB1 = new Vector(1, 2, 5);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(-7, -1, -9);
        Vector pointB2 = new Vector(1, 2, 5);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = true;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestEqualLine() {
        Vector pointA1 = new Vector(-2, -1, 5);
        Vector pointB1 = new Vector(1, 2, 7);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(-2, -1, 5);
        Vector pointB2 = new Vector(1, 2, 7);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = true;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestEqualFirstPoints() {
        Vector pointA1 = new Vector(-22, -10, 75);
        Vector pointB1 = new Vector(81, -2, 47);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(-22, -10, 75);
        Vector pointB2 = new Vector(18, 72, -7);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = true;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestEqualSecondPoints() {
        Vector pointA1 = new Vector(-2, 0, 7);
        Vector pointB1 = new Vector(8, -2, 7);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(-12, 101, -5);
        Vector pointB2 = new Vector(8, -2, 7);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = true;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestEqualFirstAndSecondPoint() {
        Vector pointA1 = new Vector(8, -2, 7);
        Vector pointB1 = new Vector(-2, 0, 7);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(-12, 101, -5);
        Vector pointB2 = new Vector(8, -2, 7);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = true;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestEqualSecondAndFirstPoint() {
        Vector pointA1 = new Vector(1, -75, 9);
        Vector pointB1 = new Vector(-87, 10, 0);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(-87, 10, 0);
        Vector pointB2 = new Vector(89, -52, 71);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = true;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotIntersected1() {
        Vector pointA1 = new Vector(-2, -11, 5);
        Vector pointB1 = new Vector(1, 2, 9);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(-2, -1, 5);
        Vector pointB2 = new Vector(1, 2, 7);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = false;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotIntersected2() {
        Vector pointA1 = new Vector(1, 2, 3);
        Vector pointB1 = new Vector(2, 3, 4);
        Line line1 = new Line(pointA1, pointB1);
        Vector pointA2 = new Vector(2, -5, 5);
        Vector pointB2 = new Vector(3, -4, 6);
        Line line2 = new Line(pointA2, pointB2);
        
        bool expected = false;

        Vector intersectPoint;
        bool actual = line1.checkIntersected(line2, out intersectPoint);
        Assert.Equal(expected, actual);
    }
}
