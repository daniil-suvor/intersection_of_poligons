namespace line;
using vector;

public class Line {
    public Line(Vector guideVector, Vector basisPoint) {
        this.guideVector = guideVector;
        this.basisPoint = basisPoint;
    }

    public Vector getPoint(double t) {
        return guideVector*t + basisPoint;
    }

    public bool pointOnLine(Vector point) {
        double t = guideVector.scalarProd(point - basisPoint)/guideVector.scalarProd(guideVector);
        return ((point - basisPoint) == t*guideVector);
    }
    
    public bool checkIntersected(Line checkLine, out Vector intersectPoint) {
        Vector subBasisPoint = checkLine.basisPoint - basisPoint;
        double a00 = guideVector.scalarProd(guideVector);
        double a01 = (-checkLine.guideVector).scalarProd(guideVector);
        double b0 = subBasisPoint.scalarProd(guideVector);
        
        double a10 = guideVector.scalarProd(-checkLine.guideVector);
        double a11 = (-checkLine.guideVector).scalarProd(-checkLine.guideVector);
        double b1 = subBasisPoint.scalarProd(-checkLine.guideVector);

        double s = 1;
        if (a00*a11 - a10*a01 != 0) {
            s = (b1*a00 - a10*b0)/(a11*a00 - a10*a01);
        }
        
        double t = (b0 - a01*s)/a00;

        intersectPoint = this.getPoint(t);
        
        return intersectPoint == checkLine.getPoint(s);

    }

    public Vector GuideVector {
        get => guideVector;
    }

    public Vector BasisPoint {
        get => basisPoint;
    }
    private Vector guideVector;
    private Vector basisPoint;
}