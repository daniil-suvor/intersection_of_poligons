namespace line;
using vector;

public class Line {
    public Line(Vector pointA, Vector pointB) {
        guideVector = pointB - pointA;
        basisPoint = pointA;
    }

    public Vector getPoint(double t) {
        return guideVector*t + basisPoint;
    }

    public bool pointOnLine(Vector point) {
        double t = guideVector.scalarProd(point - basisPoint)/guideVector.scalarProd(guideVector);
        return ((point - basisPoint) == t*guideVector);
    }
    
    public bool checkIntersected(Line l, out Vector intersectPoint) {
        Vector subBasisPoint = l.basisPoint - basisPoint;
        double a00 = guideVector.scalarProd(guideVector);
        double a01 = (-l.guideVector).scalarProd(guideVector);
        double b0 = subBasisPoint.scalarProd(guideVector);
        
        double a10 = guideVector.scalarProd(-l.guideVector);
        double a11 = (-l.guideVector).scalarProd(-l.guideVector);
        double b1 = subBasisPoint.scalarProd(-l.guideVector);

        double s = 1;
        if (a00*a11 - a10*a01 != 0) {
            s = (b1*a00 - a10*b0)/(a11*a00 - a10*a01);
        }
        
        double t = (b0 - a01*s)/a00;

        intersectPoint = this.getPoint(t);
        
        return intersectPoint == l.getPoint(s);

    }
    private Vector guideVector;
    private Vector basisPoint;
}
