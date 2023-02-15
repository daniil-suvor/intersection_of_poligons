namespace test;
using line;
using vector;

public class LineTest
{
    class LineIntersectedData : TheoryData<Line, Line, bool>
    {
        public LineIntersectedData()
        {
            Add(new Line(new Vector(1, 2, 5) - new Vector(-2, -1, 5), new Vector(-2, -1, 5)),
                new Line(new Vector(1, 2, 5) - new Vector(-7, -1, -9), new Vector(-7, -1, -9)),
                true);
            Add(new Line(new Vector(1, 2, 7) - new Vector(-2, -1, 5), new Vector(-2, -1, 5)),
                new Line(new Vector(1, 2, 7) - new Vector(-2, -1, 5), new Vector(-2, -1, 5)),
                true);
            Add(new Line(new Vector(81, -2, 47) - new Vector(-22, -10, 75), new Vector(-22, -10, 75)),
                new Line(new Vector(18, 72, -7) - new Vector(-22, -10, 75), new Vector(-22, -10, 75)),
                true);
            Add(new Line(new Vector(8, -2, 7) - new Vector(-2, 0, 7), new Vector(-2, 0, 7)),
                new Line(new Vector(8, -2, 7) - new Vector(-12, 101, -5), new Vector(-12, 101, -5)),
                true);
            Add(new Line(new Vector(-2, 0, 7) - new Vector(8, -2, 7), new Vector(8, -2, 7)),
                new Line(new Vector(8, -2, 7) - new Vector(-12, 101, -5), new Vector(-12, 101, -5)),
                true);
            Add(new Line(new Vector(-87, 10, 0) - new Vector(1, -75, 9), new Vector(1, -75, 9)),
                new Line(new Vector(89, -52, 71) - new Vector(-87, 10, 0), new Vector(-87, 10, 0)),
                true);

            Add(new Line(new Vector(1, 2, 9) - new Vector(-2, -11, 5), new Vector(-2, -11, 5)),
                new Line(new Vector(1, 2, 7) - new Vector(-2, -1, 5), new Vector(-2, -1, 5)),
                false);
            Add(new Line(new Vector(2, 3, 4) - new Vector(1, 2, 3), new Vector(1, 2, 3)),
                new Line(new Vector(3, -4, 6) - new Vector(2, -5, 5), new Vector(2, -5, 5)),
                false);
        }
    }
    [Theory]
    [ClassData(typeof(LineIntersectedData))]
    public void LineIntersectedest(Line line1, Line line2, bool expected)
    {
        Vector intersectPoint;
        bool actual = line1.areIntersected(line2, out intersectPoint);
        Assert.Equal(actual, expected);
    }
}
