namespace test;
using vector;
using triangle;
public class TriangleTest
{
    class PoinInTriangleData : TheoryData<Triangle, Vector, bool>
    {
        public PoinInTriangleData()
        {
            Add(new Triangle(new Vector(-37, 37, 37), new Vector(7, -5, 8), new Vector(12, -12, -12)),
                new Vector(0, 0, 0),
                true);
            Add(new Triangle(new Vector(0, 0, 0), new Vector(1, 0, 0), new Vector(0, 0, 1)),
                new Vector(0.1, 0, 0.1),
                true);
            Add(new Triangle(new Vector(0, 0, 444), new Vector(99, 0, 0), new Vector(-222, 0, -85)),
                new Vector(0.156, 0, 0.006),
                true);           
        }
    }
    [Theory]
    [ClassData(typeof(PoinInTriangleData))]
    public void IntersectedPlaneTest(Triangle trg, Vector checkPoint, bool expected)
    {
        bool actual = trg.poinInTriangle(checkPoint);
        Assert.Equal(actual, expected);
    }
}
