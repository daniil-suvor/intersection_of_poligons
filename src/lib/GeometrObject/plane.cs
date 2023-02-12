namespace plane;
using vector;
using line;
public class Plane {
    public Plane (Vector pointA, Vector pointB, Vector pointC) {
        Vector vectorAB = pointB  - pointA;
        Vector vectorCB = pointC  - pointA;
        normalVector = vectorAB.vectorProd(vectorCB);
        basisPoint = pointA;
        lineAB = new Line(pointA, pointB);
        lineAC = new Line(pointA, pointC);
    }
    public bool correctPlane() {
        return normalVector != new Vector();
    }

    public bool isMatched(Plane checkPlane) {
        return ((normalVector.vectorProd(checkPlane.normalVector) == new Vector()) && (this.pointOnPlane(checkPlane.basisPoint)));
    }

    public bool pointOnPlane(Vector point) {
        Vector checkVector = point - basisPoint;
        return normalVector.scalarProd(checkVector) == 0;
    }

    public bool checkLineIntersected(Line checkLine, out Vector intersectPoint) {
        Vector lineBasisPoint = checkLine.BasisPoint;
        Vector lineGuideVector = checkLine.GuideVector;

        Vector subBasisPoint = lineBasisPoint - basisPoint;

        if (normalVector.scalarProd(lineGuideVector) == 0) {
            intersectPoint = new Vector();
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

        intersectLine = new Line(lineGuideVector, new Vector());

        if (new Vector() == lineGuideVector) {
            
            return false;
        }

        if ((this.checkLineIntersected(checkPlane.lineAB, out lineBasisPoint)) ||
            (this.checkLineIntersected(checkPlane.lineAC, out lineBasisPoint)) ||
            (checkPlane.checkLineIntersected(lineAB, out lineBasisPoint)) ||
            (checkPlane.checkLineIntersected(lineAC, out lineBasisPoint))) {

            intersectLine = new Line(lineGuideVector, lineBasisPoint);
            return true;
        }

        return false;
    }
    private Vector normalVector;
    private Vector basisPoint;
    private Line lineAB;
    private Line lineAC;
}
