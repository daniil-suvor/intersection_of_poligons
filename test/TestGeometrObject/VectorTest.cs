namespace test;

using vector;
using compare;

public class VectorTest
{
    class VectorCompareData : TheoryData<Vector, Vector, bool>
    {
        public VectorCompareData()
        {
            Add(new Vector(2, 0, -2), new Vector(2, 0, -2), true);
            Add(new Vector(0, 0, 0), new Vector(0, 0, 0), true);
            Add(new Vector(-0.00000000072m, 10, 0), new Vector(-0.00000000072m, 10, 0), true);
            Add(new Vector(83000, -12000, 57), new Vector(83000, -12000, 57), true);
            Add(new Vector(0, 0, 0), new Vector(0, 0, -2), false);
            Add(new Vector(3, 1E-9m, 2), new Vector(3, 1E-10m, 2), false);
            Add(new Vector(-852015, -4562131, 4512.67845m), new Vector(364451, 13544, -2534), false);
        }
    }
    [Theory]
    [ClassData(typeof(VectorCompareData))]
    public void VectorCompareTest(Vector vec1, Vector vec2, bool expected)
    {
        bool actual = vec1 == vec2;
        Assert.Equal(actual, expected);
    }

    class VectorProdData : TheoryData<Vector, Vector, Vector>
    {
        public VectorProdData()
        {
            Add(new Vector(1, 0, 0), new Vector(0, 1, 0), new Vector(0, 0, 1));
            Add(new Vector(1, 5, 6), new Vector(8, 3, 4), new Vector(2, 44, -37));
            Add(new Vector(6, -7, 5), new Vector(-12, 14, -10), new Vector(0, 0, 0));
        }
    }
    [Theory]
    [ClassData(typeof(VectorProdData))]
    public void VectorProdTest(Vector vec1, Vector vec2, Vector expected)
    {
        Vector actual = vec1.vectorProd(vec2);
        Assert.Equal(actual, expected);
    }

    class VectorSumData : TheoryData<Vector, Vector, Vector>
    {
        public VectorSumData()
        {
            Add(new Vector(1, 0, 0), new Vector(0, 1, 0), new Vector(1, 1, 0));
            Add(new Vector(-1, 5, -6), new Vector(8, 3, 4), new Vector(7, 8, -2));
            Add(new Vector(0, 0, 0), new Vector(-12, 14, -10), new Vector(-12, 14, -10));
        }
    }
    [Theory]
    [ClassData(typeof(VectorSumData))]
    public void VectorSumTest(Vector vec1, Vector vec2, Vector expected)
    {
        Vector actual = vec1 + vec2;
        Assert.Equal(actual, expected);
    }

    class VectorSubData : TheoryData<Vector, Vector, Vector>
    {
        public VectorSubData()
        {
            Add(new Vector(1, 10, -90), new Vector(7, -1, 0), new Vector(-6, 11, -90));
            Add(new Vector(-1, 5, -6), new Vector(8, 3, 4), new Vector(-9, 2, -10));
            Add(new Vector(0, 0, 0), new Vector(-12, 14, -10), new Vector(12, -14, 10));
        }
    }
    [Theory]
    [ClassData(typeof(VectorSubData))]
    public void VectorSubTest(Vector vec1, Vector vec2, Vector expected)
    {
        Vector actual = vec1 - vec2;
        Assert.Equal(actual, expected);
    }

    class VectorConstantProdData : TheoryData<Vector, decimal, Vector>
    {
        public VectorConstantProdData()
        {
            Add(new Vector(1, 10, -90), 2.5m, new Vector(2.5m, 25, -225));
            Add(new Vector(-1, 5, -6), -10, new Vector(10, -50, 60));
            Add(new Vector(0, 0, 0), 5, new Vector(0, 0, 0));
        }
    }
    [Theory]
    [ClassData(typeof(VectorConstantProdData))]
    public void VectorConstantProdTest(Vector vec, decimal constant, Vector expected)
    {
        Vector actual = vec*constant;
        Assert.Equal(expected, actual);
    }
}
