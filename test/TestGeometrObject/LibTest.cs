namespace test;
using lib;
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
}