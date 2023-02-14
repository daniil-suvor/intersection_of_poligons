namespace triangle;
using vector;
using line;
using plane;

public class Triangle {
    public Triangle(in Vector pointA, in Vector pointB, in Vector pointC) {
        this.pointA = pointA;
        this.pointB = pointB;
        this.pointC = pointC;

        lineAB = new Line(pointA, pointB);
        lineAC = new Line(pointA, pointC);
        lineBC = new Line(pointB, pointC);

        basisPlane = new Plane(pointA, pointB, pointC);
    }

    public bool correctTriangle() {
        return basisPlane.correctPlane();
    }

    public double square() {
        return (pointB - pointA).vectorProd(pointC - pointA).norma()/2;
    }

    public bool poinInTriangle(in Vector point) {
        if ((point == pointA) || (point == pointB) || (point == pointC)) {
            return true;
        }

        Line checkLine = new Line(pointA, point);
        
        Vector intersectPoint;
        if (checkLine.checkIntersected(lineBC, out intersectPoint)) {
            if (((pointA - point).scalarProd(intersectPoint - point) <= 0) &&
                ((pointB - intersectPoint).scalarProd(pointC - intersectPoint) <= 0)) {
                return true;
            }
        }
        return false;
    }
    public List<Vector> findPointIntersected(in Line checkLine) {
        List<Vector> res = new List<Vector>();
        Vector point;
        if (lineAB.checkIntersected(checkLine, out point))
            res.Add(point);
        if (lineAC.checkIntersected(checkLine, out point))
            res.Add(point);
        if (lineBC.checkIntersected(checkLine, out point))
            res.Add(point);
        
        return res;
    }

    public bool areIntersected(in Triangle checkTriangle) {
        Line intersectLine;
        List<Vector> checkPoints = new List<Vector>();

        if (basisPlane.isMatched(checkTriangle.basisPlane)) {
            checkPoints.AddRange(checkTriangle.findPointIntersected(lineAB));
            checkPoints.AddRange(checkTriangle.findPointIntersected(lineAC));
            checkPoints.AddRange(checkTriangle.findPointIntersected(lineBC));
        } else if (basisPlane.checkPlaneIntersected(checkTriangle.basisPlane, out intersectLine)) {
            checkPoints.AddRange(this.findPointIntersected(intersectLine));
            checkPoints.AddRange(checkTriangle.findPointIntersected(intersectLine));
        }

        foreach(Vector checkPoint in checkPoints) {
            if (this.poinInTriangle(checkPoint) && checkTriangle.poinInTriangle(checkPoint))
                return true;
        }
        return false;
    }

    private Vector pointA, pointB, pointC;
    private Line lineAB, lineAC, lineBC;
    private Plane basisPlane;
}
