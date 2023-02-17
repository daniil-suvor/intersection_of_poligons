namespace compare;

public static class Compare
{
    public static bool decimalCompare(in decimal a, in decimal b) {
        return Math.Abs(Math.Abs(a) - Math.Abs(b)) < epsilon;
    }
    private const decimal epsilon = 1E-20m;
}
