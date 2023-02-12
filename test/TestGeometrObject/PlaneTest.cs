namespace test;
using plane;
using vector;
using line;
public class PlaneTest
{
    [Fact]
    public void TestNotCorectPlane1() {
        Vector pointA = new Vector(2, 0, -2);
        Vector pointB = new Vector(2, 0, -2);
        Vector pointC = new Vector(1, -7, 8);
        Plane p = new Plane(pointA, pointB, pointC);
        bool expected = false;
        bool actual = p.correctPlane();

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotCorectPlane2() {
        Vector pointA = new Vector(2, 0, -2);
        Vector pointB = new Vector(1, -7, 8);
        Vector pointC = new Vector(2, 0, -2);
        Plane p = new Plane(pointA, pointB, pointC);
        bool expected = false;
        bool actual = p.correctPlane();

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotCorectPlane3() {
        Vector pointA = new Vector(1, -7, 8);
        Vector pointB = new Vector(2, 0, -2);
        Vector pointC = new Vector(2, 0, -2);
        Plane p = new Plane(pointA, pointB, pointC);
        bool expected = false;
        bool actual = p.correctPlane();

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotCorectPlane4() {
        Vector pointA = new Vector();
        Vector pointB = new Vector();
        Vector pointC = new Vector();
        Plane p = new Plane(pointA, pointB, pointC);
        bool expected = false;
        bool actual = p.correctPlane();

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestCorectPlane1() {
        Vector pointA = new Vector(1, 1, 1);
        Vector pointB = new Vector(10, 10, 10);
        Vector pointC = new Vector(-1, 1, -1);
        Plane p = new Plane(pointA, pointB, pointC);
        bool expected = true;
        bool actual = p.correctPlane();

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestCorectPlane2() {
        Vector pointA = new Vector(1, -81, 1);
        Vector pointB = new Vector();
        Vector pointC = new Vector(-1, -1, 100);
        Plane p = new Plane(pointA, pointB, pointC);
        bool expected = true;
        bool actual = p.correctPlane();

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestMatchesPlanes1() {
        Vector pointA = new Vector(1, -81, 1);
        Vector pointB = new Vector();
        Vector pointC = new Vector(-1, -1, 100);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector pointA2 = new Vector(1, -81, 1);
        Vector pointB2 = new Vector();
        Vector pointC2 = new Vector(-1, -1, 100);
        Plane p2 = new Plane(pointA2, pointB2, pointC2);

        bool expected = true;
        bool actual = p.isMatched(p2);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestMatchesPlanes2() {
        Vector pointA = new Vector(1, 0, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 0, 1);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector pointA2 = new Vector(-7, 0, 1);
        Vector pointB2 = new Vector(3, 0, 2);
        Vector pointC2 = new Vector(-1, 0, 100);
        Plane p2 = new Plane(pointA2, pointB2, pointC2);

        bool expected = true;
        bool actual = p.isMatched(p2);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotMatchesPlanes() {
        Vector pointA = new Vector(0, 1, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 0, 1);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector pointA2 = new Vector(1, -7, 1);
        Vector pointB2 = new Vector(1, 3, 2);
        Vector pointC2 = new Vector(0, -1, 100);
        Plane p2 = new Plane(pointA2, pointB2, pointC2);

        bool expected = false;
        bool actual = p.isMatched(p2);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestPointOnPlate1() {
        Vector pointA = new Vector(0, 1, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 0, 1);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector checkPoint = new Vector(0, -709, 517);
        
        bool expected = true;
        bool actual = p.pointOnPlane(checkPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestPointOnPlate2() {
        Vector pointA = new Vector(12, 1, 0);
        Vector pointB = new Vector(12, 75, -78);
        Vector pointC = new Vector(-78, 0, 12);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector checkPoint = new Vector(-78, 0, 12);
        
        bool expected = true;
        bool actual = p.pointOnPlane(checkPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestPointOnPlate3() {
        Vector pointA = new Vector(78, 1, 80);
        Vector pointB = new Vector(-78, 1235, 25);
        Vector pointC = new Vector(10, -58, -1);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector checkPoint = new Vector(-78, 1235, 25);
        
        bool expected = true;
        bool actual = p.pointOnPlane(checkPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotPointOnPlate1() {
        Vector pointA = new Vector(78, 1, 80);
        Vector pointB = new Vector(-78, 1235, 25);
        Vector pointC = new Vector(10, -58, -1);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector checkPoint = new Vector(78, 12, 2);
        
        bool expected = false;
        bool actual = p.pointOnPlane(checkPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotPointOnPlate2() {
        Vector pointA = new Vector(-8, 11, 8);
        Vector pointB = new Vector(15, 71, -25);
        Vector pointC = new Vector(1, -5,  1);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector checkPoint = new Vector(0, 0, 0);
        
        bool expected = false;
        bool actual = p.pointOnPlane(checkPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotIntersectedLine1() {
        Vector pointA = new Vector(1, 0, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 1, 0);
        Plane p = new Plane(pointA, pointB, pointC);
    
        Vector guideVector = new Vector(1, 0, 0);
        Vector basisPoint = new Vector();
        Line l = new Line(guideVector, basisPoint);
        
        Vector incPoint;

        bool expected = false;
        bool actual = p.checkLineIntersected(l, out incPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestNotIntersectedLine2() {
        Vector pointA = new Vector(1, 9, 0);
        Vector pointB = new Vector(-7, 5, 47);
        Vector pointC = new Vector(0, -1, 0);
        Plane p = new Plane(pointA, pointB, pointC);
    
        Vector guideVector = new Vector(0, 76, 47);
        Vector basisPoint = new Vector();
        Line l = new Line(guideVector, basisPoint);
        
        Vector incPoint;

        bool expected = false;
        bool actual = p.checkLineIntersected(l, out incPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestIntersectedLine1() {
        Vector pointA = new Vector(1, 0, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 2, 0);
        Plane p = new Plane(pointA, pointB, pointC);
    
        Vector guideVector = new Vector(0, 0, 1);
        Vector basisPoint = new Vector(0, 5, 0);
        Line l = new Line(guideVector, basisPoint);
        
        Vector incPoint;

        bool expected = true;
        bool actual = p.checkLineIntersected(l, out incPoint) && (basisPoint == incPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestIntersectedLine2() {
        Vector pointA = new Vector(1, 7, -9);
        Vector pointB = new Vector(8, -4, 4);
        Vector pointC = new Vector(2, 12, 0);
        Plane p = new Plane(pointA, pointB, pointC);
    
        Vector guideVector = new Vector(15, -3, 71);
        Vector basisPoint = new Vector(8, -4, 4);
        Line l = new Line(guideVector, basisPoint);
        
        Vector incPoint;

        bool expected = true;
        bool actual = p.checkLineIntersected(l, out incPoint) && (basisPoint == incPoint);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestIntersectedPlane1() {
        Vector pointA = new Vector(1, 0, 0);
        Vector pointB = new Vector();
        Vector pointC = new Vector(0, 0, 1);
        Plane p = new Plane(pointA, pointB, pointC);

        Vector pointA2 = new Vector(-7, 10, 1);
        Vector pointB2 = new Vector(3, 0, 2);
        Vector pointC2 = new Vector(-1, -8, 100);
        Plane p2 = new Plane(pointA2, pointB2, pointC2);
        
        Line incLine;

        bool expected = true;
        bool actual = (p.checkPlaneIntersected(p2, out incLine) &&
                       p.pointOnPlane(incLine.getPoint(1)) &&
                       p2.pointOnPlane(incLine.getPoint(1))) ;

        Assert.Equal(expected, actual);
    }
}
