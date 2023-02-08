using vector;
class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(2, 2, 2);
        Vector v2 = new Vector(1, 2, 3);
        Vector v3 =  new Vector(1, 0, -1);
        Vector v4 = (v2 + v3);
        Console.WriteLine(v4);
    }
}