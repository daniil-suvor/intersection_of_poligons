namespace test;
using lib;
public class LibTest
{
    [Fact]
    public void Test1() {
        double[] arg = {0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 2, 3, -9, 1, -7, 5, 0, 7};
        bool expected = false;
        bool actual = TestLib.AreIntersected(arg);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test2() {
        double[] arg = {0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, -9, 1, -7, 5, 0, 7};
        bool expected = true;
        bool actual = TestLib.AreIntersected(arg);

        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test3() {
        double[] arg = {0, 0, 0, 50, 0, 0, 0, 0, 50, 5, 0, 5, 5, 0, 10, 10, 0, 5};
        bool expected = true;
        bool actual = TestLib.AreIntersected(arg);

        Assert.Equal(expected, actual);
    }
}
