namespace compare;

public static class Compare
{
    public static bool doubleCompare(in double a, in double b) {
        return Math.Abs(Math.Abs(a) - Math.Abs(b)) < epsilon;
    }
    private const double epsilon = 1E-10;
}
