namespace lib;

using vector;
using triangle;
using segment;

public class TestLib {
    static public IPoligon getFigure(in Vector pointA, in Vector pointB, in Vector pointC) {
        Triangle checkTiangle = new Triangle(pointA, pointB, pointC);
        if (checkTiangle.isCorrect()) {
            return checkTiangle;
        }

        Segment lineAB = new Segment(pointA, pointB);
        Segment lineAC = new Segment(pointA, pointC);
        Segment lineBC = new Segment(pointB, pointC);

        if (lineAB.isCorrect() || lineAC.isCorrect() || lineBC.isCorrect()) {
            Segment maxSegment = lineAB;
            if (lineAC.Length > maxSegment.Length) {
                maxSegment = lineAC;
            }
            if (lineBC.Length > maxSegment.Length) {
                maxSegment = lineBC;
            }
            return maxSegment;
        }

        return pointA;
    }
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

        IPoligon figure1 = getFigure(pointA1, pointB1, pointC1);
        IPoligon figure2 = getFigure(pointA2, pointB2, pointC2);

        return figure1.areIntersected(figure2);
    }
}
