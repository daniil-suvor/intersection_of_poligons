namespace line;

using vector;
using compare;

public class Line {
    public Line(in Vector guideVector, in Vector basisPoint) {
        this.basisPoint = basisPoint;
        this.guideVector = guideVector;
    }

    public Vector getPoint(in decimal t) {
        return (guideVector*t) + basisPoint;
    }
    
    public bool isCorrect() {
        return !guideVector.isZero();
    }

    public bool areIntersected(in Vector point) {
        decimal t = guideVector.scalarProd(point - basisPoint)/guideVector.scalarProd(guideVector);
        return ((point - basisPoint) == t*guideVector);
    }
    
    // finding the intersection point using the method of normal equations
    public bool areIntersected(in Line checkLine, out Vector intersectPoint) {
        Vector subBasisPoint = checkLine.basisPoint - basisPoint;
        decimal a00 = guideVector.scalarProd(guideVector);
        decimal a01 = (-checkLine.guideVector).scalarProd(guideVector);
        decimal b0 = subBasisPoint.scalarProd(guideVector);
        
        decimal a10 = guideVector.scalarProd(-checkLine.guideVector);
        decimal a11 = (-checkLine.guideVector).scalarProd(-checkLine.guideVector);
        decimal b1 = subBasisPoint.scalarProd(-checkLine.guideVector);

        decimal s;
        if (Compare.decimalCompare((a00*a11 - a10*a01), 0)) {
            s = 1;
        } else {
            s = (b1*a00 - a10*b0)/(a11*a00 - a10*a01);
        }
        decimal t = (b0 - a01*s)/a00;

        intersectPoint = checkLine.getPoint(s);
        
        return intersectPoint == this.getPoint(t);
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
