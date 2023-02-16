namespace triangle;

using vector;
using line;
using plane;
using segment;

public class Triangle : IFigure {
    public Triangle(in Vector pointA, in Vector pointB, in Vector pointC) {
        this.pointA = pointA;
        this.pointB = pointB;
        this.pointC = pointC;

        segmentAB = new Segment(pointA, pointB);
        segmentAC = new Segment(pointA, pointC);
        segmentBC = new Segment(pointB, pointC);

        basisPlane = new Plane(pointA, pointB, pointC);
    }

    public bool isCorrect() {
        return basisPlane.isCorrect();
    }

    public double square() {
        return (pointB - pointA).vectorProd(pointC - pointA).norma()/2;
    }

    public bool areIntersected(in Vector point) {
        if ((point.areIntersected(pointA)) || (point.areIntersected(pointB)) || (point.areIntersected(pointC))) {
            return true;
        }

        Line checkLine = new Line(point - pointA, pointA);
        
        Vector intersectPoint;
        if (checkLine.areIntersected(segmentBC.BasisLine, out intersectPoint)) {
            Segment checkSegment = new Segment(pointA, intersectPoint);
            return (segmentBC.areIntersected(intersectPoint) && checkSegment.areIntersected(point));
        }
        return false;
    }

    public bool areIntersected(in Segment checkSegment) {
        
        Vector intersectPoint;

        if (this.areIntersected(checkSegment.PointA)) {
            return true;
        }

        if (basisPlane.isMatched(checkSegment.BasisLine)) {
            return this.findIntersected(checkSegment);
        }
        if (basisPlane.areIntersected(checkSegment.BasisLine, out intersectPoint)) {
            return this.areIntersected(intersectPoint) && checkSegment.areIntersected(intersectPoint);
        }

        return false;
    }
    
    public bool findIntersected(in Segment checkLine) {
        return (segmentAB.areIntersected(checkLine) ||
                segmentAC.areIntersected(checkLine) ||
                segmentBC.areIntersected(checkLine));
    }

    public List<Vector> findPointIntersected(in Line checkLine) {
        List<Vector> res = new List<Vector>();
        Vector point;
        if (segmentAB.BasisLine.areIntersected(checkLine, out point))
            res.Add(point);
        if (segmentAC.BasisLine.areIntersected(checkLine, out point))
            res.Add(point);
        if (segmentBC.BasisLine.areIntersected(checkLine, out point))
            res.Add(point);
        
        return res;
    }

    public bool areIntersected(in Triangle checkTriangle) {
        Line intersectLine;
        
        if ((this.areIntersected(checkTriangle.pointC)) || (checkTriangle.areIntersected(pointC))) {
            return true;
        }

        if (basisPlane.isMatched(checkTriangle.basisPlane)) {
            return (checkTriangle.findIntersected(segmentAB) ||
                    checkTriangle.findIntersected(segmentAC) ||
                    checkTriangle.findIntersected(segmentBC));
        }
        if (basisPlane.areIntersected(checkTriangle.basisPlane, out intersectLine)) {
            List<Vector> checkPoints = new List<Vector>();

            checkPoints.AddRange(this.findPointIntersected(intersectLine));
            checkPoints.AddRange(checkTriangle.findPointIntersected(intersectLine));
            
            foreach(Vector checkPoint in checkPoints) {
                if (this.areIntersected(checkPoint) && checkTriangle.areIntersected(checkPoint))
                    return true;
            }
        }
        return false;
    }

    public bool areIntersected(in IFigure obj) {
        return obj.areIntersected(this);
    }

    private Vector pointA, pointB, pointC;
    private Segment segmentAB, segmentAC, segmentBC;
    private Plane basisPlane;
}
