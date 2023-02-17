namespace test;

using lib;

public class TestLibTest
{
    class TriangleData : TheoryData<double[], bool>
    {
        public TriangleData()
        {
            Add(new double[] {0, 0, 0, 115, 0, 0, 0, 0, 71, 0, 0, 0, -9, 1, -7, 5, 0, 7}, true);
            Add(new double[] {51, 0, 0, 0, 0, 0, 0, 0, 11, 0, 0, 0, 5, 0, 7, -9, 1, -7}, true);
            Add(new double[] {1, 0, 0, 0, 0, 1, 0, 0, 0, -9, 1, -7, 0, 0, 0, 5, 0, 7}, true);
            Add(new double[] {0, 0, 0, 50, 0, 0, 0, 0, 50, 5, 0, 5, 5, 0, 10, 10, 0, 5}, true);
            Add(new double[] {-11, 10, 0, 50, 0, 17, -9, 0, 50, -9, 0, 50, 15, 0, -10, 101, 78, 51}, true);
            Add(new double[] {0, 1, 0, 1, 0, 20, 10, 0, 0, 1, 2, 3, -9, 1, 0, -1, -2, -3}, true);
            Add(new double[] {2, 0, 0, 0, 2, 0, 0, 0, 2, 1.5, 1.5, -1, -1, 1.5, 1.5, 1.5, -1, 1.5}, true);
            Add(new double[] {-7, 17, 21, -9, 19, 21, -9, 17, 23, -7.5, 18.5, 20, -10, 18.5, 22.5, -7.5, 16, 22.5}, true);
            Add(new double[] {13.5, -6.5, 16, 14, -6.5, 15.5, 14.5, -8, 16.5, 15, -7, 15, 13, -5, 15, 13, -7, 17}, true);
            Add(new double[] {15, -7, 15, 13, -5, 15, 13, -7, 17, 13.5, -6.5, 16, 12, -5.5, 16.5, 14.5, -8, 16.5}, true);
            Add(new double[] {15, -7, 15, 13, -5, 15, 13, -7, 17, 16.6, -3.4, 9.8, 7.8, -3.4, 18.6, 13.5, -6, 15.5}, true);
            Add(new double[] {16.6, -3.4, 49.8, 7.8, -3.4, 48.6, 13.5, -6, 15.5, 15, -7, 15, 13, -5, 15, 13, -7, 17}, true);
            Add(new double[] {15, -7, 15, 13, -5, 15, 13, -7, 17, 16.6, -3.4, 19.8, 7.8, -3.4, -18.6, 13.5, -6, 15.5}, true);
            Add(new double[] {175.0, 787.0, -317.0,  173.0, 789.0, -317.0, 173.0, 787.0, -315.0, 176.6, 790.6,-308.8, 167.8, 790.6, -322.6, 173.5, 788.0, -316.5}, true);
            Add(new double[] {19, 7, -17, 17, 9, -17, 17, 7, -15, 19, 9, -19, 19, 7, -17, 17, 9, -17}, true);
            Add(new double[] {17, 9, -17, 19, 7, -17, 17, 7, -15, 19, 7, -17, 17, 9, -17, 19, 9, 19}, true);
            Add(new double[] {37, 7, -17, 17, 27, -17, 17, 7, 3, 19, 7, -5, 32, 9, -5, 19, 9, -29}, true);
            Add(new double[] {-25, 15, -13, -27, 17, -13, -27, 15, -11, -25, 15, -13, -27, 17, -13, -27, 15, -11}, true);
            Add(new double[] {-27, 17, -13, -27, 15, -11, -25, 15, -13, -25, 8, -13, -14, 13, -4, -27, 15, -11}, true);
            
            Add(new double[] {-25, 15, -13, -27, 17, -13, -27, 15, -11, -25 + 0.0000001, 15 + 0.0000001, -13 +0.0000001, -27 +0.0000001, 17 +0.0000001, -13 + 0.0000001, -27 + 0.0000001, 15 + 0.0000001, -11 + 0.0000001}, false);
            Add(new double[] {37, 7, -17, 17, 27, -17, 17, 7, 3, 19, 7, -5, 32, 9, -16, 19, 9, -29}, false);
            Add(new double[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 2, 3, -9, 1, -7, 5, 0, 7}, false);
            Add(new double[] {0, 50, 0, 50, 100, 0, -90, 0, 50, 5, 0, 5, 5, 0, 10, 10, 0, 5}, false);
        }
    }
    [Theory]
    [ClassData(typeof(TriangleData))]
    public void TriangleAreIntersected(double[] arg, bool expected)
    {
        bool actual = TestLib.AreIntersected(arg);
        Assert.Equal(expected, actual);
    }

    class TriangleSegmentData : TheoryData<double[], bool>
    {
        public TriangleSegmentData()
        {
            
            Add(new double[] {0, 0, 0, 1, 0, 0, 10, 0, 0, 1, 2, 3, -9, -5, -20, 5, 0, 7}, true);
            Add(new double[] {17, -1, 12, 28, -1, 12, 18, -1, 12, 27, 1, 15, 8, -6, -3, 25, -1, 19}, true);
            Add(new double[] {17, -1, 12, 18, -1, 12, 28, -1, 12, 8, -6, -3, 25, -1, 19, 27, 1, 15}, true);
            Add(new double[] {18, -1, 12, 17, -1, 12, 28, -1, 12, 25, -1, 19, 27, 1, 15, 8, -6, -3}, true);
            Add(new double[] {-78, 12, 0, 45, 97, -14, 57, -99, 101, 45, 97, -14, 57, -99, 101, 57.14, -51.96, 73.4}, true);
            Add(new double[] {-78, 12, 0, 45, 97, -14, 57, -99, 101, 237, -3039, 1826, 57, -99, 101, 141, -1471, 906}, true);
            Add(new double[] {987, -129, -484, 57, -99, 101, 491, -113, -172, 45, 97, -14, 57, -99, 101, -78, 12, 0}, true);
            Add(new double[] {45, 97, -14, -78, 12, 0, 57, -99, 101, -108.468, 2603.644, -1484.735, 723.8376, -10990.6808, 6491.527, 117, -1079, 676}, true);
            Add(new double[] {54.36, -55.88, 75.7, 45.432, 89.944, -9.86, 56.952, -98.216, 100.54, -78, 12, 0, 45, 97, -14, 57, -99, 101}, true);
            Add(new double[] {7, -8, 9, 57, -8, 9, 7, -8, 59, 12, -8, 14, 12, -8, 19, 12, -8, 19}, true);
            Add(new double[] {7, -8, 9, 57, -8, 9, 7, -8, 59, 12, -8, 14, 12, -8, 19, 12, -8, 99}, true);
            Add(new double[] {12, -8, 14, 12, -8, 99, 12, -8, 7, -8, 59, 19, 7, -8, 9, 57, -8, 9}, true);
            Add(new double[] {1, -7, 9, 13, 5, 13, 13, 5, 13, 7, -1, 11, 12, -18, 0, -1, 11, 10}, true);

            Add(new double[] {0, 0, 0, -10, 0, 0, 10, 0, 0, 1, 2, 3, -9, 1, -7, 5, 0, 7}, false);
            Add(new double[] {0, 0, 0, 1, 0, 0, 10, 0, 0, 1, 2, 3, -9, -5, -7, 5, 0, 7}, false);

        }
    }
    [Theory]
    [ClassData(typeof(TriangleSegmentData))]
    public void TriangleSegmentAreIntersected(double[] arg, bool expected)
    {
        bool actual = TestLib.AreIntersected(arg);
        Assert.Equal(expected, actual);
    }

    class TrianglePointData : TheoryData<double[], bool>
    {
        public TrianglePointData()
        {
            Add(new double[] {-37, 37, 37, 7, -5, 8, 12, -12, -12, 0, 0, 0, 0, 0, 0, 0, 0, 0}, true);
            Add(new double[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 0.1, 0, 0.1, 0.1, 0, 0.1, 0.1, 0, 0.1}, true);
            Add(new double[] {0.156, 0, 0.006, 0.156, 0, 0.006, 0.156, 0, 0.006, 0, 0, 444, 99, 0, 0, -222, 0, -85}, true);
            Add(new double[] {125, 857, -741, 0, 65, 78, 54, -25, -67, 125, 857, -741, 125, 857, -741, 125, 857, -741}, true);
            Add(new double[] {1, -7, 9, 13, 5, 13, -74, 69, 49, 7, -1, 11, 7, -1, 11, 7, -1, 11}, true);

            Add(new double[] {1, -7, 9, 13, 5, 13, -74, 69, 49, -74.00005, 69, 49, -74.00005, 69, 49, -74.00005, 69, 49}, false);
            Add(new double[] {1, -7, 9, 13, 5, 13, -74, 69, 49, -74, 69.00000009, 49, -74, 69.00000009, 49, -74, 69.00000009, 49}, false);
            Add(new double[] {-74, 69, 49.000003, -74, 69, 49.000003, -74, 69, 49.000003, 13, 5, 13, -74, 69, 49, 1, -7, 9}, false);
        }
    }
    [Theory]
    [ClassData(typeof(TrianglePointData))]
    public void TrianglePointAreIntersected(double[] arg, bool expected)
    {
        bool actual = TestLib.AreIntersected(arg);
        Assert.Equal(expected, actual);
    }
}
