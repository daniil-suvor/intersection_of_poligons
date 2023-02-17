namespace test;

using plane;
using vector;
using line;

public class PlaneTest
{
    class CheckPlaneData : TheoryData<Plane, bool>
    {
        public CheckPlaneData()
        {
            Add(new Plane(new Vector(2, 0, -2), new Vector(2, 0, -2), new Vector(1, -7, 8)), false);
            Add(new Plane(new Vector(2, 0, -2), new Vector(1, -7, 8), new Vector(2, 0, -2)), false);
            Add(new Plane(new Vector(1, -7, 8), new Vector(2, 0, -2), new Vector(2, 0, -2)), false);
            Add(new Plane(new Vector(0, 0, 0), new Vector(0, 0, 0), new Vector(0, 0, 0)), false);

            Add(new Plane(new Vector(1, 1, 1), new Vector(10, 10, 10), new Vector(-1, 1, -1)), true);
            Add(new Plane(new Vector(1, -81, 1), new Vector(0, 0, 0), new Vector(-1, -1, 100)), true);
        }
    }
    [Theory]
    [ClassData(typeof(CheckPlaneData))]
    public void CheckPlaneDataTest(Plane pl, bool expected)
    {
        bool actual = pl.isCorrect();
        Assert.Equal(actual, expected);
    }
    
    class MatchedPlaneData : TheoryData<Plane, Plane, bool>
    {
        public MatchedPlaneData()
        {
            Add(new Plane(new Vector(1, -81, 1), new Vector(0, 0, 0), new Vector(-1, -1, 100)),
                new Plane(new Vector(1, -81, 1), new Vector(0, 0, 0), new Vector(-1, -1, 100)),
                true);
            Add(new Plane(new Vector(1, 0, 0), new Vector(0, 0, 0), new Vector(0, 0, 1)),
                new Plane(new Vector(-7, 0, 1), new Vector(3, 0, 2), new Vector(-1, 0, 100)),
                true);
            Add(new Plane(new Vector(0, 1, 0), new Vector(0, 0, 0), new Vector(0, 0, 1)),
                new Plane(new Vector(1, -7, 1), new Vector(1, 3, 2), new Vector(0, -1, 100)),
                false);
        }
    }
    [Theory]
    [ClassData(typeof(MatchedPlaneData))]
    public void MatchedPlaneTest(Plane pl1, Plane pl2, bool expected)
    {
        bool actual = pl1.isMatched(pl2);
        Assert.Equal(actual, expected);
    }

    class PointOnPlaneData : TheoryData<Plane, Vector, bool>
    {
        public PointOnPlaneData()
        {
            Add(new Plane(new Vector(0, 1, 0), new Vector(0, 0, 0), new Vector(0, 0, 1)),
                new Vector(0, -709, 517),
                true);
            Add(new Plane(new Vector(12, 1, 0), new Vector(12, 75, -78), new Vector(-78, 0, 12)),
                new Vector(-78, 0, 12),
                true);
            Add(new Plane(new Vector(78, 1, 80), new Vector(-78, 1235, 25), new Vector(10, -58, -1)),
                new Vector(-78, 1235, 25),
                true);
            Add(new Plane(new Vector(-78, -78, -78), new Vector(78, 78, 78), new Vector(10, -58, -1)),
                new Vector(0, 0, 0),
                true);
            Add(new Plane(new Vector(78, 1, 80), new Vector(-78, 1235, 25), new Vector(10, -58, -1)),
                new Vector(78, 12, 2),
                false);
            Add(new Plane(new Vector(-8, 11, 8), new Vector(15, 71, -25), new Vector(1, -5,  1)),
                new Vector(0, 0, 0),
                false);
        }
    }
    [Theory]
    [ClassData(typeof(PointOnPlaneData))]
    public void PointOnPlaneTest(Plane pl, Vector point, bool expected)
    {
        bool actual = pl.areIntersected(point);
        Assert.Equal(actual, expected);
    }

    class IntersectedLineData : TheoryData<Plane, Line, bool>
    {
        public IntersectedLineData()
        {
            Add(new Plane(new Vector(1, 9, 0), new Vector(-7, 5, 47), new Vector(0, -1, 0)),
                new Line(new Vector(0, 0, 0) - new Vector(0, 76, 47), new Vector(0, 76, 47)),
                false);
            Add(new Plane(new Vector(1, 0, 0), new Vector(0, 0, 0), new Vector(0, 1, 0)),
                new Line(new Vector(0, 0, 0) - new Vector(1, 0, 0), new Vector(1, 0, 0)),
                true);
            Add(new Plane(new Vector(1, 0, 0), new Vector(0, 0, 0), new Vector(0, 2, 0)),
                new Line(new Vector(0, 5, 1) - new Vector(0, 5, 0), new Vector(0, 5, 0)),
                true);
            Add(new Plane(new Vector(1, 7, -9), new Vector(8, -4, 4), new Vector(2, 12, 0)),
                new Line(new Vector(23, -7, 75) - new Vector(8, -4, 4), new Vector(8, -4, 4)),
                true);
            
        }
    }
    [Theory]
    [ClassData(typeof(IntersectedLineData))]
    public void IntersectedLineTest(Plane pl, Line lin, bool expected)
    {
        Vector incPoint;

        bool actual = pl.areIntersected(lin, out incPoint) && pl.areIntersected(incPoint) && lin.areIntersected(incPoint);
        Assert.Equal(actual, expected);
    }

    class IntersectedPlaneData : TheoryData<Plane, Plane, bool>
    {
        public IntersectedPlaneData()
        {
            Add(new Plane(new Vector(1, 0, 0), new Vector(0, 0, 0), new Vector(0, 0, 1)),
                new Plane(new Vector(-7, 10, 1),new Vector(3, 0, 2), new Vector(-1, -8, 100)),
                true);
            Add(new Plane(new Vector(1, 15, 85), new Vector(-4, 8, 41), new Vector(-1, -5, 97)),
                new Plane(new Vector(-4 + 0.000007m, 8 + 0.000007m, 41 + 0.000007m), new Vector(1 + 0.000007m, 15 + 0.000007m, 85 + 0.000007m), new Vector(-1 + 0.000007m, -5 + 0.000007m , 97 + 0.000007m)),
                false);
        }
    }
    [Theory]
    [ClassData(typeof(IntersectedPlaneData))]
    public void IntersectedPlaneTest(Plane pl1, Plane pl2, bool expected)
    {
        Line incLine;
        bool actual = (pl1.areIntersected(pl2, out incLine) &&
                       pl1.areIntersected(incLine.getPoint(80.1m)) &&
                       pl2.areIntersected(incLine.getPoint(-10.2m))) ;
        Assert.Equal(expected, actual);
    }
}
