namespace plane;

using vector;
using line;

public class Plane {
    public Plane (in Vector pointA, in Vector pointB, in Vector pointC) {
        Vector vectorAB = pointB - pointA;
        Vector vectorAC = pointC - pointA;
        normalVector = vectorAB.vectorProd(vectorAC);
        basisPoint = pointA;
        lineAB = new Line(vectorAB, pointA);
        lineAC = new Line(vectorAC, pointC);
    }
    public bool isCorrect() {
        return !normalVector.isZero();
    }

    public bool isMatched(in Plane checkPlane) {
        return ((normalVector.vectorProd(checkPlane.normalVector).isZero()) && (this.areIntersected(checkPlane.basisPoint)));
    }

    public bool isMatched(in Line checkLine) {
        return ((normalVector.areOrthogonal(checkLine.GuideVector)) && 
                (this.areIntersected(checkLine.BasisPoint)));
    }
    public bool areIntersected(in Vector point) {
        Vector checkVector = point - basisPoint;
        return normalVector.areOrthogonal(checkVector);
    }

    public bool areIntersected(in Line checkLine, out Vector intersectPoint) {
        Vector lineBasisPoint = checkLine.BasisPoint;
        Vector lineGuideVector = checkLine.GuideVector;

        Vector subBasisPoint = lineBasisPoint - basisPoint;

        if (this.isMatched(checkLine)) {
            intersectPoint = checkLine.BasisPoint;
            return true;
        }

        if (normalVector.areOrthogonal(lineGuideVector)) {
            intersectPoint = new Vector(0, 0, 0);
            return false;
        }
        
        double t = -(normalVector.scalarProd(subBasisPoint) / normalVector.scalarProd(lineGuideVector));
        intersectPoint = checkLine.getPoint(t);
        return true;
    }

    public bool areIntersected(in Plane checkPlane, out Line intersectLine) {
        Vector lineBasisPoint;
        Vector lineGuideVector;
        lineGuideVector = normalVector.vectorProd(checkPlane.normalVector);

        intersectLine = new Line(new Vector(0, 0, 0), new Vector(0, 0, 0));

        if (lineGuideVector.isZero()) {
            
            return false;
        }

        if ((this.areIntersected(checkPlane.lineAB, out lineBasisPoint)) ||
            (this.areIntersected(checkPlane.lineAC, out lineBasisPoint)) ||
            (checkPlane.areIntersected(lineAB, out lineBasisPoint)) ||
            (checkPlane.areIntersected(lineAC, out lineBasisPoint))) {

            intersectLine = new Line(lineGuideVector, lineBasisPoint);
            return true;
        }

        return false;
    }
    private Vector normalVector;
    private Vector basisPoint;
    private Line lineAB, lineAC;
}
