namespace lib;
using vector;
using triangle;
public class TestLib {
    static public bool AreIntersected(double[] coordinates) {
        if (coordinates.Length != 18) {
            return false;
        }
        Vector pointA1 = new Vector(coordinates[0], coordinates[1], coordinates[2]);
        Vector pointB1 = new Vector(coordinates[3], coordinates[4], coordinates[5]);
        Vector pointC1 = new Vector(coordinates[6], coordinates[7], coordinates[8]);

        Vector pointA2 = new Vector(coordinates[9], coordinates[10], coordinates[11]);
        Vector pointB2 = new Vector(coordinates[12], coordinates[13], coordinates[14]);
        Vector pointC2 = new Vector(coordinates[15], coordinates[16], coordinates[17]);

        Triangle triangle1 = new Triangle(pointA1, pointB1, pointC1);
        Triangle triangle2 = new Triangle(pointA2, pointB2, pointC2);

        return triangle1.areIntersected(triangle2);
    }
}
