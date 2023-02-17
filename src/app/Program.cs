using lib;
class Program
{
    static void Main(string[] args)
    {
        double[] coordinates = {-27, 17, -13, -27, 15, -11, -25, 15, -13, -25, 8, -13, -14, 13, -4, -27, 15, -11};
        bool result = TestLib.AreIntersected(coordinates);
        Console.WriteLine(result);
    }
}
