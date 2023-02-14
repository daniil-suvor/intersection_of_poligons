namespace plane;
using vector;
using line;
public class Plane {
    public Plane (Vector pointA, Vector pointB, Vector pointC) {
        Vector vectorAB = pointB - pointA;
        Vector vectorAC = pointC - pointA;
        normalVector = vectorAB.vectorProd(vectorAC);
        basisPoint = pointA;
        lineAB = new Line(pointA, pointB);
        lineAC = new Line(pointA, pointC);
    }
    public bool correctPlane() {
        return !normalVector.isZero();
    }

    public bool isMatched(Plane checkPlane) {
        return ((normalVector.vectorProd(checkPlane.normalVector).isZero()) && (this.pointOnPlane(checkPlane.basisPoint)));
    }

    public bool pointOnPlane(Vector point) {
        Vector checkVector = point - basisPoint;
        return Math.Abs(normalVector.scalarProd(checkVector)) < Constants.compareEpsilon;
    }

    public bool checkLineIntersected(Line checkLine, out Vector intersectPoint) {
        Vector lineBasisPoint = checkLine.BasisPoint;
        Vector lineGuideVector = checkLine.GuideVector;

        Vector subBasisPoint = lineBasisPoint - basisPoint;

        if (Math.Abs(normalVector.scalarProd(lineGuideVector)) < Constants.compareEpsilon) {
            intersectPoint = new Vector(0, 0, 0);
            return false;
        }
        
        double t = -(normalVector.scalarProd(subBasisPoint) / normalVector.scalarProd(lineGuideVector));
        intersectPoint = checkLine.getPoint(t);
        return true;
    }

    public bool checkPlaneIntersected(Plane checkPlane, out Line intersectLine) {
        Vector lineBasisPoint;
        Vector lineGuideVector;
        lineGuideVector = normalVector.vectorProd(checkPlane.normalVector);

        intersectLine = new Line(new Vector(0, 0, 0), new Vector(0, 0, 0));

        if (lineGuideVector.isZero()) {
            
            return false;
        }

        if ((this.checkLineIntersected(checkPlane.lineAB, out lineBasisPoint)) ||
            (this.checkLineIntersected(checkPlane.lineAC, out lineBasisPoint)) ||
            (checkPlane.checkLineIntersected(lineAB, out lineBasisPoint)) ||
            (checkPlane.checkLineIntersected(lineAC, out lineBasisPoint))) {

            intersectLine.GuideVector = lineGuideVector;
            intersectLine.BasisPoint = lineBasisPoint;
            return true;
        }

        return false;
    }
    private Vector normalVector;
    private Vector basisPoint;
    private Line lineAB, lineAC;
}
